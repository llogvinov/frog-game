using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class BasePathMover : MonoBehaviour
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
            if (MovePositions.Count < 1)
            {
                MoveEnded?.Invoke();
                return;
            }
            
            NextPosition = MovePositions.Dequeue();
            _moveCoroutine = StartCoroutine(MoveTransform());
        }
        
        private IEnumerator MoveTransform()
        {
            while ((NextPosition - transform.position).sqrMagnitude > 0.001f)
            {
                Move();
                yield return null;
            }
            
            Utils.SnapToPosition(transform, NextPosition);
            MoveToNextPosition();
        }

        protected virtual void Move()
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                NextPosition, 
                _moveSpeed * Time.deltaTime);
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