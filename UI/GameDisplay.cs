using System;
using Reversedrooms.Models;
using Reversedrooms.Models.Items;

namespace Reversedrooms.UI
{
    public class GameDisplay
    {
        private Character _player;

        public void Display(Character player, Location location)
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
            Console.WriteLine();
            Console.WriteLine("[LEVEL #0]");
            Console.WriteLine($"[Location Type: {location.Name}]");
            Console.WriteLine();
            Console.WriteLine($"# {location.Description}");
            if (location.Items.Count > 0)
            {
                Console.WriteLine("# You also see some items on the ground.");
            }
        }

        public void Update(Character player)
        {
            _player = player;
        }
    }
}