using System;
using System.Collections.Generic;
using Reversedrooms.Data;
using Reversedrooms.Data.LevelData;
using Reversedrooms.Models;
using Reversedrooms.Models.Items;
using Reversedrooms.Patterns.Strategy;
using Reversedrooms.Systems;
using Reversedrooms.UI;

namespace Reversedrooms
{
    public class Game
    {
        private Character _player;
        private NavigationSystem _navigationSystem;
        private InventorySystem _inventorySystem;
        private SanitySystem _sanitySystem;
        private CombatSystem _combatSystem;
        private UserInterface _ui;
        private Location _currentLocation;
        private bool _gameOver;

        public Game()
        {
            _player = new Character("Alex", 10, 10, 10);
            var locations = Level0.CreateLevel();
            _currentLocation = Level0.GetStartingLocation(locations);
            _navigationSystem = new NavigationSystem(_currentLocation);
            _inventorySystem = new InventorySystem(_player);
            _sanitySystem = new SanitySystem(_player);
            _combatSystem = new CombatSystem();
            _ui = new UserInterface();
            _player.Attach(_ui);
            _gameOver = false;
        }

        public void Run()
        {
            Prologue.Display();

            while (!_gameOver)
            {
                if (_player.Health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You have died. Game Over.");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey(true);
                    break;
                }

                _sanitySystem.CheckDarkness(_currentLocation);
                _sanitySystem.CheckEnemy(_currentLocation);
                _currentLocation = _navigationSystem.CurrentLocation;

                if (_currentLocation.Enemy != null && _currentLocation.Enemy.Health > 0)
                {
                    HandleCombat();
                }
                else
                {
                    HandleExploration();
                }

                _player.IsFlashlightOn = false;
            }
        }

        private void HandleExploration()
        {
            // Больше не вызываем _ui.DisplayGame здесь, это сделает OptionSelector
            var options = new List<string>();

            if (_currentLocation.Name == "Lift Room")
            {
                options.Add("Use lift");
            }

            foreach (var item in _currentLocation.Items)
            {
                if (item is Note note)
                {
                    options.Add($"Read {note.Name}");
                }
                else
                {
                    options.Add($"Take {item.Name}");
                }
            }

            options.AddRange(_navigationSystem.GetNavigationOptions());
            options.Add("Use item from your inventory");
            _ui.DisplayGame(_player, _currentLocation);
            Console.WriteLine();

            // Передаем _ui, _player и _currentLocation в OptionSelector
            var selector = new OptionSelector(options, _ui, _player, _currentLocation);
            var selectedOption = selector.SelectOption();

            if (selectedOption == "Use lift")
            {
                Ending.Display();
                _gameOver = true;
                return;
            }

            if (selectedOption.StartsWith("Take "))
            {
                var itemName = selectedOption.Substring(5);
                var item = _currentLocation.Items.Find(i => i.Name == itemName);
                if (item != null)
                {
                    _player.Inventory.Add(item);
                    _currentLocation.Items.Remove(item);
                }
            }
            else if (selectedOption.StartsWith("Read "))
            {
                var noteName = selectedOption.Substring(5);
                var note = _currentLocation.Items.Find(i => i.Name == noteName) as Note;
                if (note != null)
                {
                    Console.Clear();
                    Console.WriteLine($"# {note.Description}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
            else if (selectedOption.StartsWith("Go "))
            {
                var direction = selectedOption.Substring(3);
                _navigationSystem.Move(Enum.Parse<Direction>(direction, true));
            }
            else if (selectedOption == "Use item from your inventory")
            {
                HandleInventory();
            }
        }

        private void HandleCombat()
        {
            while (_currentLocation.Enemy != null && _currentLocation.Enemy.Health > 0 && _player.Health > 0)
            {
                // Убираем вызов _ui.DisplayCombat здесь, так как это сделает OptionSelector
                var options = new List<string>
                {
                    "Use weapon from your inventory",
                    "Use item from your inventory",
                    "Try to escape [50%]"
                };

                // Передаем _ui, _player, _currentLocation и флаг isCombatMode
                var selector = new OptionSelector(options, _ui, _player, _currentLocation, isCombatMode: true);
                var selectedOption = selector.SelectOption();

                if (selectedOption == "Use weapon from your inventory")
                {
                    var weaponOptions = new List<string>();
                    foreach (var item in _player.Inventory)
                    {
                        if (item is Weapon weapon)
                        {
                            weaponOptions.Add(weapon.Name);
                        }
                    }
                    weaponOptions.Add("Back to combat menu");

                    selector = new OptionSelector(weaponOptions, _ui, _player, _currentLocation, isCombatMode: true);
                    var selectedWeapon = selector.SelectOption();

                    if (selectedWeapon != "Back to combat menu")
                    {
                        var weapon = _player.Inventory.Find(i => i.Name == selectedWeapon) as Weapon;
                        _combatSystem.SetAttackStrategy(weapon);
                        if (_combatSystem.ExecuteAttack(_player, _currentLocation.Enemy))
                        {
                            Console.Clear();
                            _ui.DisplayCombat(_player, _currentLocation); // Показываем интерфейс после атаки
                            Console.WriteLine();
                            Console.WriteLine(_combatSystem._attackStrategy.GetAttackDescription());
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.Clear();
                            _ui.DisplayCombat(_player, _currentLocation); // Показываем интерфейс при неудаче
                            Console.WriteLine();
                            Console.WriteLine("Not enough stamina or sanity to attack!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                    }
                }
                else if (selectedOption == "Use item from your inventory")
                {
                    _ui.DisplayGame(_player, _currentLocation); // Показываем интерфейс перед выбором предмета
                    var itemOptions = new List<string>
                    {
                        "Flashlight",
                        "Back to combat menu"
                    };
                    foreach (var item in _player.Inventory)
                    {
                        if (item is ConsumableItem consumable)
                        {
                            itemOptions.Insert(itemOptions.Count - 1, consumable.Name);
                        }
                    }

                    selector = new OptionSelector(itemOptions, _ui, _player, _currentLocation, isCombatMode: true);
                    var selectedItem = selector.SelectOption();

                    if (selectedItem != "Back to combat menu")
                    {
                        if (selectedItem == "Flashlight" && _currentLocation.Enemy.IsWeakToFlashlight())
                        {
                            _combatSystem.SetAttackStrategy(new FlashlightStrategy());
                            var flashlight = _player.Inventory.Find(i => i.Name == "Flashlight") as Tool;
                            if (flashlight.Use(_player))
                            {
                                _combatSystem.ExecuteAttack(_player, _currentLocation.Enemy);
                                Console.Clear();
                                Console.WriteLine(_combatSystem._attackStrategy.GetAttackDescription());
                                Console.WriteLine("The enemy is defeated!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                _currentLocation.Enemy = null;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("No charges left in the flashlight!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                            }
                        }
                        else
                        {
                            _inventorySystem.UseItem(selectedItem);
                        }
                    }
                }
                else if (selectedOption == "Try to escape [50%]")
                {
                    var random = new Random();
                    if (random.NextDouble() < 0.5)
                    {
                        Console.Clear();
                        Console.WriteLine("You successfully escaped!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        var directions = _navigationSystem.GetNavigationOptions();
                        selector = new OptionSelector(directions, _ui, _player, _currentLocation);
                        var direction = selector.SelectOption().Substring(3);
                        _navigationSystem.Move(Enum.Parse<Direction>(direction, true));
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You failed to escape!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                    }
                }

                if (_currentLocation.Enemy != null && _currentLocation.Enemy.Health > 0)
                {
                    _currentLocation.Enemy.Attack(_player);
                }
            }
        }

        private void HandleInventory()
        {
            _ui.DisplayInventory(_player);
            var options = _inventorySystem.GetInventoryOptions();
            var selector = new OptionSelector(options);
            var selectedOption = selector.SelectOption();

            if (selectedOption != "Back to main menu")
            {
                var itemName = selectedOption.Split(':')[0];
                _inventorySystem.UseItem(itemName);
            }
        }
        public bool EndGame()
        {
            _gameOver = true;
            return true;
        }
    }
}