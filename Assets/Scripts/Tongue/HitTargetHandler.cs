using System;
using System.Collections.Generic;
using FrogGame;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class HitTargetHandler : MonoBehaviour
    {
        public Action<int> TakeDamage;
        public Action<int> AddScore;
        
        [SerializeField] private TongueHead _tongueHead;

        private List<EatableEnemy> _caughtEnemies;

        private void Start()
        {
            _tongueHead.MoveEnded += OnHitEnded;
            
            _caughtEnemies = new List<EatableEnemy>();
        }

        private void OnDestroy()
        {
            _tongueHead.MoveEnded -= OnHitEnded;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EatableEnemy eatableEnemy))
            {
                OnEatableEnemyHit(eatableEnemy);
            }
            else if (other.TryGetComponent(out DamageableEnemy damageableEnemy))
            {
                OnDamageableEnemyHit(damageableEnemy);
            }
        }

        private void OnEatableEnemyHit(EatableEnemy enemy)
        {
            if (!enemy.enabled) return;
            
            enemy.transform.parent = _tongueHead.transform;
            enemy.transform.localPosition = Vector3.zero;
            
            enemy.Mover.StopMoving();
            _caughtEnemies.Add(enemy);
        }

        private void OnDamageableEnemyHit(DamageableEnemy enemy)
        {
            TakeDamage?.Invoke(enemy.DamageToGive);
            
            ReleaseCaughtEnemies();
            _tongueHead.ForceMoveToOriginalPosition();
        }

        private void ReleaseCaughtEnemies()
        {
            if (_caughtEnemies.Count == 0) return;
            
            foreach (var enemy in _caughtEnemies)
            {
                enemy.transform.parent = enemy.Pool.transform;
                enemy.Mover.ContinueMoving();
            }
            
            _caughtEnemies.Clear();
        }

        private void OnHitEnded()
        {
            if (_caughtEnemies.Count == 0) return;
            
            foreach (var enemy in _caughtEnemies)
            {
                enemy.Release();
                AddScore?.Invoke(enemy.PointsToAdd);
            }

            _caughtEnemies.Clear();
        }
    }
}