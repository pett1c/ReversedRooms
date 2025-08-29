using System.Collections.Generic;
using Reversedrooms.Models;

namespace Reversedrooms.Systems
{
    public class NavigationSystem
    {
        private Location _currentLocation;

        public NavigationSystem(Location startingLocation)
        {
            _currentLocation = startingLocation;
        }

        public Location CurrentLocation => _currentLocation;

        public void Move(Direction direction)
        {
            if (_currentLocation.Connections.TryGetValue(direction, out var newLocation))
            {
                _currentLocation = newLocation;
            }
        }

        public List<string> GetNavigationOptions()
        {
            var options = new List<string>();
            foreach (var connection in _currentLocation.Connections)
            {
                options.Add($"Go {connection.Key.ToString().ToLower()}");
            }
            return options;
        }
    }
}