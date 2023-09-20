using UnityEngine;

namespace FrogGame.Enemy
{
    public class EatableEnemy : Enemy
    {
        [SerializeField] private int _pointsToAdd;

        public int PointsToAdd => _pointsToAdd;

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
    
        protected override void OnFinalTargetReached()
        {
            enabled = false;
        }

        private void OnReleaseFromTargetStarted()
        {
            Debug.Log("release started");
            Mover.MoveEnded -= OnFinalTargetReached;
        }

        private void OnReleasedFromTarget()
        {
            Debug.Log("released");
            Release();
        }
    }
}