using Player;

namespace PowerUps
{
    public class HealthPowerUp : ActivatedPowerUp
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