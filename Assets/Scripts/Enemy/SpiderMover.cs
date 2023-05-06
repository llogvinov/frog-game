using System.Collections.Generic;
using Core;
using UnityEngine;

namespace FrogGame.Enemy
{
    public class SpiderMover : EnemyMover
    {
        private float _xPosition;
        private float _lowestYPosition = 1f;
        
        private Vector3 _spawnPosition;
        
        protected override void SetPositions()
        {
            MovePositions = new Queue<Vector3>();
            _spawnPosition = transform.position;
            _xPosition = _spawnPosition.x;

            for (int i = 0; i < MovePositionNumber; i++)
            {
                float yPosition = Random.Range(_lowestYPosition, GameManager.Instance.HalfHeight);
                
                var nextPosition = new Vector3(_xPosition, yPosition);
            
                MovePositions.Enqueue(nextPosition);
                MovePositions.Enqueue(_spawnPosition);
            }
        }
    }
}