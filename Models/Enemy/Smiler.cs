using ReversedRooms_fast.Models;

namespace Reversedrooms.Models.Enemy
{
    public class Smiler : Enemy
    {
        public Smiler() : base("Smiler", 1, "=)", "A luminous smile and pair of eyes appear in the darkness. The entity slowly floats toward you.")
        {
        }

        public override bool IsWeakToFlashlight()
        {
            return true;
        }

        public override void Attack(Character player)
        {
            player.ChangeSanity(-1);
            player.ChangeHealth(-1);
        }
    }
}