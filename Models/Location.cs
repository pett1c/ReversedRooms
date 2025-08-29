using Reversedrooms.Models.Items;
using Reversedrooms.Models.Enemy;
using System.Collections.Generic;

namespace Reversedrooms.Models
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public class Location
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsDark { get; }
        public Dictionary<Direction, Location> Connections { get; } = new Dictionary<Direction, Location>();
        public List<Item> Items { get; } = new List<Item>();
        public Reversedrooms.Models.Enemy.Enemy Enemy { get; set; } // Явно указываем класс Enemy

        public Location(string name, string description, bool isDark)
        {
            Name = name;
            Description = description;
            IsDark = isDark;
        }

        public void AddConnection(Direction direction, Location location)
        {
            Connections[direction] = location;
        }
    }
}