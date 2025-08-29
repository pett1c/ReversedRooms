using Reversedrooms.Models;
using Reversedrooms.Patterns.Observer;

namespace Reversedrooms.UI
{
    public class UserInterface : IObserver
    {
        private GameDisplay _gameDisplay;
        private CombatDisplay _combatDisplay;
        private InventoryDisplay _inventoryDisplay;

        public UserInterface()
        {
            _gameDisplay = new GameDisplay();
            _combatDisplay = new CombatDisplay();
            _inventoryDisplay = new InventoryDisplay();
        }

        public void DisplayGame(Character player, Location location)
        {
            _gameDisplay.Display(player, location);
        }

        public void DisplayCombat(Character player, Location location)
        {
            _combatDisplay.Display(player, location);
        }

        public void DisplayInventory(Character player)
        {
            _inventoryDisplay.Display(player);
        }

        public void Update(ISubject subject)
        {
            if (subject is Character character)
            {
                _gameDisplay.Update(character);
                _combatDisplay.Update(character);
                _inventoryDisplay.Update(character);
            }
        }
    }
}