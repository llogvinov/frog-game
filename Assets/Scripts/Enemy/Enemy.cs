﻿using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyMover _mover;
    
        private EnemyPool _pool;

        public EnemyPool Pool
        {
            get => _pool;
            set => _pool = value;
        }

        public EnemyMover Mover => _mover;

        protected virtual void OnEnable()
        {
            _mover.MoveEnded += OnFinalTargetReached;
        }

        protected virtual void OnDisable()
        {
            _mover.MoveEnded -= OnFinalTargetReached;
        }

        protected abstract void OnFinalTargetReached();

        public void Release()
        {
            _pool.ReturnToPool(this);
            transform.parent = _pool.transform;
        }
    }
}