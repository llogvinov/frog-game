using System;
using System.Collections.Generic;
using Core;
using FrogGirl;
using UnityEngine;

namespace Enemy
{
    public class EatableEnemyMover : EnemyMover
    {
        private Target _target;

        public Action ReleaseStarted;
        public Action Released;

        private void OnEnable()
        {
            MoveEnded += OccupyTarget;
        }

        private void OnDisable()
        {
            MoveEnded -= OccupyTarget;
            MoveEnded -= OnReleased;
        }
        
        public void ReleaseEnemyFromTarget()
        {
            MoveEnded += OnReleased;
            
            ReleaseStarted?.Invoke();
            MovePositions = new Queue<Vector3>();
            AddFinalPositionOffScreen();
            MoveToNextPosition();
        }

        private void OnReleased()
        {
            Released?.Invoke();
        }

        private void OccupyTarget()
        {
            MoveEnded -= OccupyTarget;
            _target.OccupyTarget(this);
        }

        protected override void AddFinalPosition()
        {
            _target = Game.FrogGirl.GetTarget();
            var lastPosition = _target.Position;
            MovePositions.Enqueue(lastPosition);
        }
    }
}