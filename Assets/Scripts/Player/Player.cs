using Settings;
using Tongue;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private HealthSettings _healthSettings;

        private Health _health;
        private Score _score;
        private HitTargetHandler _hitTargetHandler;

        public Health Health => _health;

        public Score Score => _score;

        public HealthSettings HealthSettings => _healthSettings;

        private void Start()
        {
            _health = new Health(_healthSettings.MinHealth, _healthSettings.MaxHealth);
            _score = new Score();

            HitTargetHandler.DamageableEnemyHit += _health.TakeDamage;
            HitTargetHandler.EatableEnemyHit += _score.AddScore;
        }

        private void OnDestroy()
        {
            HitTargetHandler.DamageableEnemyHit -= _health.TakeDamage;
            HitTargetHandler.EatableEnemyHit -= _score.AddScore;
        }
    }
}