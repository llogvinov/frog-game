using Core;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : PooledObject
    {
        [SerializeField] private EnemyMover _mover;
    
        public EnemyMover Mover => _mover;

        protected virtual void OnEnable()
        {
            Mover.MoveEnded += OnFinalTargetReached;
        }

        protected virtual void OnDisable()
        {
            Mover.MoveEnded -= OnFinalTargetReached;
        }

        protected abstract void OnFinalTargetReached();
    }
}