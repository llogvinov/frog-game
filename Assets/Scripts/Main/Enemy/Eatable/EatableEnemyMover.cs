using System;
using System.Collections.Generic;
using Core;
using Core.Factory;
using Main.FrogGirl;
using UnityEngine;

namespace Main.Enemy.Eatable
{
    public class EatableEnemyMover : EnemyMover
    {
        private Girl _girl;
        private Target _target;

        public Action ReleaseStarted;
        public Action Released;

        private void OnEnable()
        {
            MoveEnded += OccupyTarget;
            Init();
        }

        private void OnDisable()
        {
            MoveEnded -= OccupyTarget;
            MoveEnded -= OnReleased;
        }

        private void Init()
        {
            _girl = AllServices.Container.Single<IGameFactory>().Girl;
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
            _target = _girl.GetTarget();
            var lastPosition = _target.Position;
            MovePositions.Enqueue(lastPosition);
        }
    }
}