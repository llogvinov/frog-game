using System.Collections.Generic;
using Core;
using UnityEngine;

namespace FrogGame.Enemy
{
    public abstract class EnemyMover : BasePathMover
    {
        [SerializeField] private uint _movePositionNumber;
    
        private bool _isFacingRight;

        protected uint MovePositionNumber => _movePositionNumber;

        public void Initialize()
        {
            SetPositions();
            MoveToNextPosition();
        }
    
        protected virtual void SetPositions()
        {
            MovePositions = new Queue<Vector3>();
            for (int i = 0; i < _movePositionNumber; i++)
            {
                var nextPosition = new Vector3(
                    Random.Range(GameBootstrapper.HalfWidth, GameBootstrapper.HalfWidth),
                    Random.Range(0, GameBootstrapper.HalfHeight));
            
                MovePositions.Enqueue(nextPosition);
            }
        
            AddFinalPosition();
        }

        protected virtual void AddFinalPosition() { }

        private void Flip()
        {
            var currentScale = transform.localScale;
            currentScale.x *= -1f;
            transform.localScale = currentScale;

            _isFacingRight = !_isFacingRight;
        }

        protected override void MoveToNextPosition()
        {
            base.MoveToNextPosition();
        
            if (NextPosition.x < transform.position.x && _isFacingRight) Flip();
            if (NextPosition.x > transform.position.x && !_isFacingRight) Flip();
        }

        public void ContinueMoving()
        {
            if (MovePositions.Count < 1)
            {
                AddFinalPosition();
            }
            MoveToNextPosition();
        }

    }
}