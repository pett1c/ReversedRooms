using System.Collections.Generic;
using Reversedrooms.Models;
using Reversedrooms.Models.Items;

namespace Reversedrooms.Systems
{
    public class InventorySystem
    {
        private Character _player;

        public InventorySystem(Character player)
        {
            _player = player;
        }

        public void UseItem(string itemName)
        {
            var item = _player.Inventory.Find(i => i.Name == itemName);
            if (item == null) return;

            if (item is ConsumableItem consumable)
            {
                consumable.Use(_player);
                if (consumable.Uses <= 0)
                {
                    _player.Inventory.Remove(item);
                }
            }
            else if (item is Tool tool && item.Name == "Flashlight")
            {
                if (tool.Use(_player))
                {
                    _player.IsFlashlightOn = true;
                }
            }
        }

        public List<string> GetInventoryOptions()
        {
            var options = new List<string>();
            foreach (var item in _player.Inventory)
            {
                if (item is ConsumableItem consumable)
                {
                    options.Add($"{item.Name}: [{consumable.Uses}]");
                }
                else if (item is Tool tool && item.Name == "Flashlight")
                {
                    options.Add($"{item.Name}: [{tool.Charges}]");
                }
                else
                {
                    options.Add(item.Name);
                }
            }
            options.Add("Back to main menu");
            return options;
        }
    }
}