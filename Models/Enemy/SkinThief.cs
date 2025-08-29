using ReversedRooms_fast.Models;

namespace Reversedrooms.Models.Enemy
{
    public class SkinThief : Enemy
    {
        public SkinThief() : base("SkinThief", 10, "GRRR", "A tall humanoid with no skin, oozing darkness. It stares at you with empty eyes.")
        {
        }

        public override bool IsWeakToFlashlight()
        {
            return false;
        }

        public override void Attack(Character player)
        {
            player.ChangeHealth(-3);
            player.ChangeSanity(-2);
        }
    }
}