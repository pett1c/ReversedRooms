namespace Reversedrooms.Patterns.Strategy
{
    public class FlashlightStrategy : IAttackStrategy
    {
        public int CalculateDamage() => 10;
        public int GetStaminaCost() => 0;
        public string GetAttackDescription() => "You shine your flashlight at the creature.";
    }
}