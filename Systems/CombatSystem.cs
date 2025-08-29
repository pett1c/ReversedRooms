using Reversedrooms.Models;
using Reversedrooms.Models.Enemy;
using Reversedrooms.Models.Items;
using Reversedrooms.Patterns.Strategy;

namespace Reversedrooms.Systems
{
    public class CombatSystem
    {
        public IAttackStrategy _attackStrategy;

        public void SetAttackStrategy(IAttackStrategy strategy)
        {
            _attackStrategy = strategy;
        }

        public bool ExecuteAttack(Character player, Enemy enemy)
        {
            int staminaCost = _attackStrategy.GetStaminaCost();
            if (player.Stamina < staminaCost || !player.CanAttack())
            {
                return false;
            }

            player.ChangeStamina(-staminaCost);
            int damage = _attackStrategy.CalculateDamage();

            // Если враг — Smiler, то атака срабатывает только с FlashlightStrategy
            if (enemy is Smiler && _attackStrategy is not FlashlightStrategy)
            {
                return false; // Оружие не наносит урон Smiler-у
            }

            enemy.TakeDamage(damage);
            return true;
        }
    }
}