using Player;

namespace Bonus
{
    public class HealthPowerUp : ActivatedBonus
    {
        private readonly Health _health;
        private readonly int _addAmount;

        public HealthPowerUp(Health health, int addAmount)
        {
            _health = health;
            _addAmount = addAmount;
        }

        public override void Apply()
        {
            _health.Heal(_addAmount);
            Applied?.Invoke();
        }
    }
}