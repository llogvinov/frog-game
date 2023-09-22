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

        public TongueHead TongueHead => _hitTargetHandler.TongueHead;

        private void Start()
        {
            _hitTargetHandler = GetComponentInChildren<HitTargetHandler>();
            _health = new Health(_healthSettings.MinHealth, _healthSettings.MaxHealth);
            _score = new Score();

            _hitTargetHandler.DamageableEnemyHit += _health.TakeDamage;
            _hitTargetHandler.EatableEnemyHit += _score.AddScore;
        }

        private void OnDestroy()
        {
            _hitTargetHandler.DamageableEnemyHit -= _health.TakeDamage;
            _hitTargetHandler.EatableEnemyHit -= _score.AddScore;
        }
    }
}