namespace Reversedrooms.Patterns.Strategy
{
    public class KnifeStrategy : IAttackStrategy
    {
        public int CalculateDamage() => 3;
        public int GetStaminaCost() => 1;
        public string GetAttackDescription() => "You strike with your hunting knife.";
    }
}