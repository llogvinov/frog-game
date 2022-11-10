using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class TongueHead : MonoBehaviour
    {
        public Action HitEnded;
        
        private SpriteRenderer _headVisual;
        
        private Queue<Vector3> _movePositions;
        private Vector3 _originalPosition;
        private Vector3 _nextPosition;

        public SpriteRenderer Visual => _headVisual;

        public Vector3 OriginalPosition => _originalPosition;

        private void Awake()
        {
            _headVisual = GetComponent<SpriteRenderer>();
            _headVisual.enabled = false;
            
            _originalPosition = transform.position;
        }
        
        public void Move(float speed, float t)
        {
            transform.position = Vector3.MoveTowards(transform.position, _nextPosition, speed * t);
            CheckSnappingToPosition(transform);
        }

        public void SetPath(Vector3 hitPosition)
        {
            _movePositions = new Queue<Vector3>();
            _movePositions.Enqueue(hitPosition);
            _movePositions.Enqueue(_originalPosition);
            
            _nextPosition = _movePositions.Dequeue();
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
                HitEnded?.Invoke();
            }
        }
        
        private void SnapToPosition(Transform objectToSnap, Vector3 position)
        {
            objectToSnap.position = position;
        }

        public void ForceEndHit()
        {
            if (_nextPosition == _originalPosition) return;

            _nextPosition = _movePositions.Dequeue();
        }
        
    }
}