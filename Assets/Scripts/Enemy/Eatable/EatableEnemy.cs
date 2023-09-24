using UnityEngine;

namespace Enemy.Eatable
{
    public class EatableEnemy : Enemy
    {
        [SerializeField] private global::Enemy.Eatable.Eatable _eatable;

        public global::Enemy.Eatable.Eatable Eatable => _eatable;
        
        public bool IsEatable
        {
            get => Eatable.enabled;
            private set => Eatable.enabled = value;
        }

        private EatableEnemyMover _eatableEnemyMover;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            if (_eatableEnemyMover == null) 
                _eatableEnemyMover = (EatableEnemyMover) Mover;
            _eatableEnemyMover.ReleaseStarted += OnReleaseFromTargetStarted;
            _eatableEnemyMover.Released += OnReleasedFromTarget;
        }

        protected override void OnDisable()
        {
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
    }
}