using Core;
using FrogGirl;

namespace FrogGame.Enemy
{
    public class EatableEnemyMover : EnemyMover
    {
        private Target _target;

        private void OnEnable()
        {
            MoveEnded += OnFinalTargetReached;
        }

        private void OnDisable()
        {
            MoveEnded -= OnFinalTargetReached;
        }

        private void OnFinalTargetReached()
        {
            _target.OccupyTarget();
            GameManager.Instance.FrogGirl.CheckAllTargetsOccupied();
        }

        protected override void AddFinalPosition()
        {
            var frogGirl = GameManager.Instance.FrogGirl;
            _target = frogGirl.Target;
            var lastPosition = _target.Position;
            MovePositions.Enqueue(lastPosition);
        }
    }
}