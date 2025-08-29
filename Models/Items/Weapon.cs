using Reversedrooms.Patterns.Strategy;

namespace Reversedrooms.Models.Items
{
    public class Weapon : Item, IAttackStrategy
    {
        public int Damage { get; }
        public int StaminaCost { get; }

        public Weapon(string name, string description, int damage, int staminaCost) : base(name, description)
        {
            Damage = damage;
            StaminaCost = staminaCost;
        }

        public int CalculateDamage() => Damage;
        public int GetStaminaCost() => StaminaCost;
        public string GetAttackDescription() => $"You attack with your {Name}.";
    }
}