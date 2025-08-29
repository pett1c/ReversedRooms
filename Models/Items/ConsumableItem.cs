namespace Reversedrooms.Models.Items
{
    public class ConsumableItem : Item
    {
        public int Uses { get; private set; }

        public ConsumableItem(string name, string description, int uses) : base(name, description)
        {
            Uses = uses;
        }

        public void Use(Character player)
        {
            if (Uses <= 0) return;

            if (Name == "Almond Water")
            {
                player.ChangeHealth(1);
                player.ChangeSanity(1);
            }
            else if (Name == "Water Bottle")
            {
                player.ChangeStamina(1);
            }
            else if (Name == "Batteries")
            {
                var flashlight = player.Inventory.Find(item => item.Name == "Flashlight") as Tool;
                flashlight?.AddCharges(1);
            }

            Uses--;
        }
    }
}