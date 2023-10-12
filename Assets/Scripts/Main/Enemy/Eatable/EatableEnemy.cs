namespace Main.Enemy.Eatable
{
    public class EatableEnemy : Enemy
    {
        public bool IsEatable { get; private set; }

        private EatableEnemyMover _eatableEnemyMover;
        
        protected override void OnEnable()
        {
            base.OnEnable();

            IsEatable = true;
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