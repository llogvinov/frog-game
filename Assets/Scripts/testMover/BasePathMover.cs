using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogGame
{
    public class BasePathMover: MonoBehaviour
    {
        public Action MoveEnded; 
        
        [SerializeField] private float _moveSpeed;
        
        protected Queue<Vector3> MovePositions { get; set; }
        protected Vector3 OriginalPosition;
        private Vector3 _nextPosition;

        private Coroutine _moveCoroutine;

        private void Awake()
        {
            OriginalPosition = transform.position;
        }

        protected void MoveToNextPosition()
        {
            _nextPosition = MovePositions.Dequeue();
            _moveCoroutine = StartCoroutine(MoveTransform());
        }
        
        protected IEnumerator MoveTransform()
        {
            while (!((_nextPosition - transform.position).sqrMagnitude < 0.001f))
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    _nextPosition, 
                    _moveSpeed * Time.deltaTime);

                yield return null;
            }
            
            SnapToPosition(transform, _nextPosition);
            if (MovePositions.Count > 0)
            {
                MoveToNextPosition();
            }
            else
            {
                MoveEnded?.Invoke();
            }
        }

        private void SnapToPosition(Transform transformToSnap, Vector3 position)
        {
            transformToSnap.position = position;
        }

        public void ForceEndMoving()
        {
            StopCoroutine(_moveCoroutine);
        }
        
        public void ForceMoveToOriginalPosition()
        {
            if (_nextPosition == OriginalPosition) return;

            _nextPosition = MovePositions.Dequeue();
        }
    }
}