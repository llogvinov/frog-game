using System;
using System.Collections.Generic;
using Core;
using Core.Factory;
using Enemy.Damageable;
using Enemy.Eatable;
using PowerUps.TimePowerUps;
using UnityEngine;

namespace Tongue
{
    [RequireComponent(typeof(Collider2D))]
    public class HitTargetHandler : MonoBehaviour
    {
        public Action<int> DamageableEnemyHit;
        public Action<int> EatableEnemyHit;
        
        public static Action<int> ComboDone;
        
        [SerializeField] private TongueHead _tongueHead;

        private Collider2D _collider;
        private List<EatableEnemy> _caughtEnemies;

        public TongueHead TongueHead => _tongueHead;

        private void Start()
        {
            _tongueHead.HitStarted += OnHitStarted;
            _tongueHead.MoveEnded += OnHitEnded;

            _collider = GetComponent<Collider2D>();
            _collider.enabled = false;
            
            _caughtEnemies = new List<EatableEnemy>();
        }

        private void OnDestroy()
        {
            _tongueHead.HitStarted -= OnHitStarted;
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
            if (!enemy.IsEatable) return;
            
            enemy.transform.parent = _tongueHead.transform;
            enemy.transform.localPosition = Vector3.zero;
            enemy.Mover.ForceStopMoving();
            
            if (!_caughtEnemies.Contains(enemy)) 
                _caughtEnemies.Add(enemy);
        }

        private void OnDamageableEnemyHit(DamageableEnemy enemy)
        {
            _collider.enabled = false;
            DamageableEnemyHit?.Invoke(enemy.DamageToGive);
            
            ReleaseCaughtEnemies();
            _tongueHead.ForceMoveToOriginalPosition();
        }

        private void ReleaseCaughtEnemies()
        {
            if (_caughtEnemies.Count == 0) return;
            
            foreach (var enemy in _caughtEnemies)
            {
                enemy.ResetParent();
                enemy.Mover.ContinueMoving();
            }
            
            _caughtEnemies.Clear();
        }

        private void OnHitStarted()
        {
            _collider.enabled = true;
        }

        private void OnHitEnded()
        {
            _collider.enabled = false;
            if (_caughtEnemies.Count == 0) 
                return;
            
            if (_caughtEnemies.Count > 1) 
                ComboDone?.Invoke(_caughtEnemies.Count);
            
            foreach (var enemy in _caughtEnemies)
            {
                if (enemy.TryGetComponent(out PowerUpEnemy powerUpEnemy))
                {
                    var score = AllServices.Container.Single<IGameFactory>().Player.Score;
                    powerUpEnemy.DoPowerUp(new ScoreMultiplierPowerUp(score, 2f, 10f));
                }
                if (enemy.TryGetComponent(out Eatable eatable))
                {
                    EatableEnemyHit?.Invoke(eatable.EatablePoints);
                }

                enemy.Release();
            }

            _caughtEnemies.Clear();
        }
    }
}