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

        private void Start()
        {
            _health = new Health(_healthSettings.MinHealth, _healthSettings.MaxHealth);
            _score = new Score();

            _hitTargetHandler = GetComponentInChildren<HitTargetHandler>();
            if (_hitTargetHandler != null)
            {
                _hitTargetHandler.TakeDamage += _health.TakeDamage;
                _hitTargetHandler.AddScore += _score.AddScore;
            }
        }

        private void OnDestroy()
        {
            _hitTargetHandler.TakeDamage -= _health.TakeDamage;
            _hitTargetHandler.AddScore -= _score.AddScore;
        }
    }
}