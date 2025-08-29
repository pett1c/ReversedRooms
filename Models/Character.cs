using Reversedrooms.Models.Items;
using Reversedrooms.Patterns.Observer;
using System.Collections.Generic;

namespace Reversedrooms.Models
{
    public class Character : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public string Name { get; }
        public int Health { get; private set; }
        public int Stamina { get; private set; }
        public int Sanity { get; private set; }
        public List<Item> Inventory { get; } = new List<Item>();
        public bool IsFlashlightOn { get; set; }

        public Character(string name, int health, int stamina, int sanity)
        {
            Name = name;
            Health = health;
            Stamina = stamina;
            Sanity = sanity;

            Inventory.Add(new Tool("Flashlight", "A flashlight to light up dark areas.", 10));
            Inventory.Add(new Weapon("Hunting Knife", "A sharp knife for close combat.", 3, 1));
            Inventory.Add(new Weapon("Prosthetic Leg", "A heavy prosthetic leg used as a weapon.", 5, 2));
        }

        public void ChangeHealth(int value)
        {
            Health = Math.Max(0, Math.Min(10, Health + value));
            Notify();
        }

        public void ChangeStamina(int value)
        {
            Stamina = Math.Max(0, Math.Min(10, Stamina + value));
            Notify();
        }

        public void ChangeSanity(int value)
        {
            Sanity = Math.Max(0, Math.Min(10, Sanity + value));
            Notify();
        }

        public bool CanAttack()
        {
            return Sanity > 1;
        }

        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}