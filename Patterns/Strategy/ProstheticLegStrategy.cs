namespace Reversedrooms.Patterns.Strategy
{
    public class ProstheticLegStrategy : IAttackStrategy
    {
        public int CalculateDamage() => 5;
        public int GetStaminaCost() => 2;
        public string GetAttackDescription() => "You swing your prosthetic leg at the enemy.";
    }
}