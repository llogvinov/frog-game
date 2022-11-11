using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class HitTargetHandler : MonoBehaviour
    {
        [SerializeField] private TongueHead _tongueHead;

        private List<EatableEnemy> _caughtEnemies;

        private void OnEnable()
        {
            _tongueHead.HitEnded += OnHitEnded;
        }

        private void OnDisable()
        {
            _tongueHead.HitEnded -= OnHitEnded;
        }

        private void Awake()
        {
            _caughtEnemies = new List<EatableEnemy>();
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
            // take damage
            ReleaseCaughtEnemies();
            _tongueHead.ForceEndHit();
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
            
            // add logic to add score or smth for caught
            foreach (var enemy in _caughtEnemies)
            {
                enemy.Release();
            }

            _caughtEnemies.Clear();
        }
    }
}