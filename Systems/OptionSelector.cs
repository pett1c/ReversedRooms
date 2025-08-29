using System;
using System.Collections.Generic;
using Reversedrooms.Models;
using Reversedrooms.UI;

namespace Reversedrooms.Systems
{
    public class OptionSelector
    {
        private List<string> _options;
        private int _selectedIndex;
        private UserInterface _ui;
        private Character _player;
        private Location _location;
        private bool _isCombatMode; // Новый флаг для определения режима

        public OptionSelector(List<string> options, UserInterface ui = null, Character player = null, Location location = null, bool isCombatMode = false)
        {
            _options = options;
            _selectedIndex = 0;
            _ui = ui;
            _player = player;
            _location = location;
            _isCombatMode = isCombatMode;
        }

        public string SelectOption()
        {
            while (true)
            {
                Console.Clear();

                // Отображаем интерфейс в зависимости от режима
                if (_ui != null && _player != null && _location != null)
                {
                    if (_isCombatMode)
                    {
                        _ui.DisplayCombat(_player, _location);
                        Console.WriteLine();
                        Console.WriteLine("[COMBAT STATUS]: Your turn.");
                    }
                    else
                    {
                        _ui.DisplayGame(_player, _location);
                        Console.WriteLine();
                        Console.WriteLine("# What do you want to do?");
                    }
                }

                // Отображаем опции
                for (int i = 0; i < _options.Count; i++)
                {
                    Console.WriteLine($"> {_options[i]}" + (i == _selectedIndex ? " <" : ""));
                }

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    _selectedIndex = (_selectedIndex - 1 + _options.Count) % _options.Count;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _selectedIndex = (_selectedIndex + 1) % _options.Count;
                }
                else if (key == ConsoleKey.Enter)
                {
                    return _options[_selectedIndex];
                }
            }
        }
    }
}