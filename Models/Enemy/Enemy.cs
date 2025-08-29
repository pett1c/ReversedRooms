namespace Reversedrooms.Models.Enemy
{
    public abstract class Enemy
    {
        public string Name { get; }
        public int Health { get; protected set; }
        public string Symbol { get; }
        public string Description { get; }

        protected Enemy(string name, int health, string symbol, string description)
        {
            Name = name;
            Health = health;
            Symbol = symbol;
            Description = description;
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }

        public abstract bool IsWeakToFlashlight();
        public abstract void Attack(Character player);
    }
}