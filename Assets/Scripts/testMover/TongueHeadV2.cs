using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrogGame
{
    public class TongueHeadV2 : BasePathMover
    {
        private Vector3 _hitPosition;
        
        private PlayerInput _playerInput;

        private void Start()
        {
            _playerInput = GetComponentInParent<PlayerInput>();
            _playerInput.HitSetEvent += OnHitSet;
        }

        private void OnDestroy()
        {
            _playerInput.HitSetEvent += OnHitSet;
        }

        private void OnHitSet(Vector3 hitPosition)
        {
            _hitPosition = hitPosition;
            _hitPosition.z = 0f;

            MovePositions = new Queue<Vector3>();
            MovePositions.Enqueue(_hitPosition);
            MovePositions.Enqueue(OriginalPosition);
            
            MoveToNextPosition();
        }
    }
}