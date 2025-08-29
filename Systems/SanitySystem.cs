using Reversedrooms.Models;

namespace Reversedrooms.Systems
{
    public class SanitySystem
    {
        private Character _player;

        public SanitySystem(Character player)
        {
            _player = player;
        }

        public void CheckDarkness(Location location)
        {
            if (location.IsDark && !_player.IsFlashlightOn)
            {
                _player.ChangeSanity(-1);
            }
        }

        public void CheckEnemy(Location location)
        {
            if (location.Enemy != null)
            {
                _player.ChangeSanity(-1);
            }
        }
    }
}