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
        protected Vector3 NextPosition;

        private Coroutine _moveCoroutine;

        private void Awake()
        {
            OriginalPosition = transform.position;
        }

        protected virtual void MoveToNextPosition()
        {
            if (!(MovePositions.Count > 0) && NextPosition != null)
            {
                _moveCoroutine = StartCoroutine(MoveTransform());
            }
            
            NextPosition = MovePositions.Dequeue();
            _moveCoroutine = StartCoroutine(MoveTransform());
        }
        
        private IEnumerator MoveTransform()
        {
            while (!((NextPosition - transform.position).sqrMagnitude < 0.001f))
            {
                Move();
                yield return null;
            }
            
            SnapToPosition(transform, NextPosition);
            if (MovePositions.Count > 0)
            {
                MoveToNextPosition();
            }
            else
            {
                MoveEnded?.Invoke();
            }
        }

        protected virtual void Move()
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                NextPosition, 
                _moveSpeed * Time.deltaTime);
        }

        private void SnapToPosition(Transform transformToSnap, Vector3 position)
        {
            transformToSnap.position = position;
        }

        public void ForceStopMoving()
        {
            StopCoroutine(_moveCoroutine);
        }
        
        public void ForceMoveToOriginalPosition()
        {
            if (NextPosition == OriginalPosition) return;
            ForceMoveToPosition(OriginalPosition);
        }

        public void ForceMoveToPosition(Vector3 newPosition)
        {
            NextPosition = newPosition;
            MovePositions.Clear();
        }
    }
}