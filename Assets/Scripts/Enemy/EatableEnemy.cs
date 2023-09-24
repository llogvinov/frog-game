using Core;
using UnityEngine;

namespace Enemy
{
    public class EatableEnemy : Enemy
    {
        [SerializeField] private Eatable _eatable;

        public Eatable Eatable => _eatable;
        
        public bool IsEatable
        {
            get => Eatable.enabled;
            private set => Eatable.enabled = value;
        }

        private EatableEnemyMover _eatableEnemyMover;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            Pool.ObjectReturned += ResetParent;
            
            if (_eatableEnemyMover == null) 
                _eatableEnemyMover = (EatableEnemyMover) Mover;
            _eatableEnemyMover.ReleaseStarted += OnReleaseFromTargetStarted;
            _eatableEnemyMover.Released += OnReleasedFromTarget;
        }

        protected override void OnDisable()
        {
            Pool.ObjectReturned -= ResetParent;
            _eatableEnemyMover.ReleaseStarted -= OnReleaseFromTargetStarted;
            _eatableEnemyMover.Released -= OnReleasedFromTarget;
            base.OnDisable();
        }

        public void ResetParent() =>
            transform.parent = Pool.transform;

        protected override void OnFinalTargetReached() => 
            IsEatable = false;

        private void OnReleaseFromTargetStarted() => 
            Mover.MoveEnded -= OnFinalTargetReached;

        private void OnReleasedFromTarget() => 
            Release();

        private void ResetParent(PooledObject pooledObject) => 
            pooledObject.transform.parent = Pool.transform;
    }
}