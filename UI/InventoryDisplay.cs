using System;
using Reversedrooms.Models;
using Reversedrooms.Models.Items;

namespace Reversedrooms.UI
{
    public class InventoryDisplay
    {
        private Character _player;

        public void Display(Character player)
        {
            _player = player;
            Console.Clear();
            Console.WriteLine($"[{player.Name}]");
            Console.WriteLine($"[HP]: [{new string('█', player.Health)}{new string('░', 10 - player.Health)}]");
            Console.WriteLine($"[ST]: [{new string('█', player.Stamina)}{new string('░', 10 - player.Stamina)}]");
            Console.WriteLine($"[SA]: [{new string('█', player.Sanity)}{new string('░', 10 - player.Sanity)}]");
            Console.WriteLine();
            Console.WriteLine("[INVENTORY]");
            foreach (var item in player.Inventory)
            {
                if (item is Tool tool && item.Name == "Flashlight")
                {
                    Console.WriteLine($"Flashlight: [{new string('█', tool.Charges)}{new string('░', 10 - tool.Charges)}]");
                }
                else if (item is ConsumableItem consumable)
                {
                    Console.WriteLine($"{item.Name}: [{new string('█', consumable.Uses)}{new string('░', 3 - consumable.Uses)}]");
                }
                else
                {
                    Console.WriteLine($"{item.Name}: [DMG: {(item as Weapon)?.Damage} | ST: {(item as Weapon)?.StaminaCost}]");
                }
            }
        }

        public void Update(Character player)
        {
            _player = player;
        }
    }
}