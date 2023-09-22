using FrogGirl;

namespace PowerUps
{
    public class ReleaseEnemiesPowerUp : ActivatedPowerUp
    {
        private readonly Target[] _targets;

        public ReleaseEnemiesPowerUp(Target[] targets)
        {
            _targets = targets;
        }

        public override void Apply()
        {
            foreach (var target in _targets) 
                target.ReleaseEnemyFromTarget();

            Applied?.Invoke();
        }
    }
}