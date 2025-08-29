using ReversedRooms_fast.Models;

namespace Reversedrooms.Models.Enemy
{
    public class DeathMoth : Enemy
    {
        public DeathMoth() : base("DeathMoth", 3, "BZZZ", "A giant moth-like creature with glowing wings. It buzzes aggressively as it charges at you.")
        {
        }

        public override bool IsWeakToFlashlight()
        {
            return false;
        }

        public override void Attack(Character player)
        {
            player.ChangeHealth(-2);
            player.ChangeSanity(-1);
        }
    }
}