using System.Collections.Generic;
using System.Linq;
using Core;
using Settings;
using UnityEngine;

namespace Main.Enemy
{
    public abstract class EnemyMover : BasePathMover
    {
        [SerializeField] private uint _movePositionNumber;
        [Space]
        [SerializeField] private EnemySettingsGroup _enemySettingsGroup;
        
        protected uint MovePositionNumber => _movePositionNumber;

        private EnemySettings MoveSettings
        {
            get
            {
                if (_moveSettings == null)
                {
                    _moveSettings = GetMoveSettings();
                    if (_moveSettings == null)
                        Debug.LogError("Move settings not found");
                }
                
                return _moveSettings;
            }
        }
        
        private bool _isFacingRight;
        private EnemySettings _moveSettings;

        public void Initialize()
        {
            _isFacingRight = false;
            SetPositions();
            MoveToNextPosition();
        }
        
        public void SetMoveSettings()
        {
            _moveSpeed = MoveSettings.MoveSpeed;
            _movePositionNumber = MoveSettings.MovePointsNumber;
        }
    
        protected virtual void SetPositions()
        {
            MovePositions = new Queue<Vector3>();
            for (int i = 0; i < _movePositionNumber; i++)
            {
                var nextPosition = new Vector3(
                    Random.Range(-GameBootstrapper.HalfWidth, GameBootstrapper.HalfWidth),
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
        
        protected void AddFinalPositionOffScreen()
        {
            var lastPosition = Utils.RandomPositionOffTheScreen();
            MovePositions.Enqueue(lastPosition);
        }

        private EnemySettings GetMoveSettings() =>
            _enemySettingsGroup.EnemySettingsList
                .FirstOrDefault(spawnerSettings => gameObject.name.Contains(spawnerSettings.EnemyName));
    }
}