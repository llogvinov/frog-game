using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Tongue : MonoBehaviour
    {
        [SerializeField] private TongueBase _tongueBase;
        [SerializeField] private Transform _tongueHead;
        [SerializeField] private float _hitSpeed;
        
        private PlayerInput _playerInput;
        private Queue<Vector3> _movePositions;
        private Vector3 _originalPosition;
        private Vector3 _nextPosition;
        private bool _isHitSet;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();

            _originalPosition = _tongueHead.position;
        }

        private void OnEnable() => _playerInput.HitSetEvent += OnHitSet;

        private void OnDisable() => _playerInput.HitSetEvent -= OnHitSet;

        private void Update()
        {
            if (_isHitSet)
            {
                Move(_tongueHead, _hitSpeed, Time.deltaTime);
            }
        }
        
        private void Move(Transform objectToMove, float speed, float t)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, _nextPosition, speed * t);
            CheckSnappingToPosition(objectToMove);
            _tongueBase.ScaleTongue(_originalPosition, _tongueHead.position);
        }

        private void OnHitSet(Vector3 hitPosition)
        {
            hitPosition.z = 0f;
            
            _movePositions = new Queue<Vector3>();
            _movePositions.Enqueue(hitPosition);
            _movePositions.Enqueue(_originalPosition);

            _nextPosition = _movePositions.Dequeue();
            
            _isHitSet = true;
        }

        private void CheckSnappingToPosition(Transform objectToCheck)
        {
            if (!((_nextPosition - objectToCheck.position).sqrMagnitude < 0.001f)) return;
            
            SnapToPosition(objectToCheck, _nextPosition);
                
            if (_movePositions.Count > 0)
            {
                _nextPosition = _movePositions.Dequeue();
            }
            else
            {
                _isHitSet = false;
            }
        }
        
        private void SnapToPosition(Transform objectToSnap, Vector3 position)
        {
            objectToSnap.position = position;
        }
        
    }
}