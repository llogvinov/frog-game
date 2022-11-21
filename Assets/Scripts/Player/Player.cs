using System;
using FrogGame;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private int _minHealth;
        [SerializeField] private int _maxHealth;
        [Header("Score")] 
        [SerializeField] private ScorePresenter _scorePresenter;
        
        private Health _health;
        private Score _score;
        private HitTargetHandler _hitTargetHandler;

        public Score PlayerScore => _score;
        
        private void Start()
        {
            _health = new Health(_minHealth, _maxHealth);
            _score = new Score(_scorePresenter);

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