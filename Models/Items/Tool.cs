namespace Reversedrooms.Models.Items
{
    public class Tool : Item
    {
        public int Charges { get; private set; }

        public Tool(string name, string description, int charges) : base(name, description)
        {
            Charges = charges;
        }

        public void AddCharges(int amount)
        {
            Charges += amount;
        }

        public bool Use(Character player)
        {
            if (Charges <= 0) return false;
            Charges--;
            return true;
        }
    }
}