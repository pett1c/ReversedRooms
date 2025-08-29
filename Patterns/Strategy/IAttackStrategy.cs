namespace Reversedrooms.Patterns.Strategy
{
    public interface IAttackStrategy
    {
        int CalculateDamage();
        int GetStaminaCost();
        string GetAttackDescription();
    }
}