using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EnemyMover : MonoBehaviour
{
    public Action FinalTargetReached;
    
    [SerializeField] private uint _movePositionNumber;
    [SerializeField] private float _speed;

    protected Queue<Vector3> MovePositions;
    private Vector3 _nextPosition;
    private bool _isMoving;

    protected uint MovePositionNumber => _movePositionNumber;

    private void Update()
    {
        if (_isMoving)
        {
            Move(Time.deltaTime, FinalTargetReached);
        }
    }

    public void Move(float t, Action onFinalTargetReached)
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _speed * t);
        
        if ((_nextPosition - transform.position).sqrMagnitude < 0.001f)
        {
            SnapToPosition(_nextPosition);

            if (MovePositions.Count > 0)
            {
                _nextPosition = MovePositions.Dequeue();
            }
            else
            {
                _isMoving = false;
                onFinalTargetReached?.Invoke();
            }
        }
    }

    public void Initialize()
    {
        SetPositions();
        StartMoving();
    }
    
    protected virtual void SetPositions()
    {
        MovePositions = new Queue<Vector3>();

        for (int i = 0; i < _movePositionNumber; i++)
        {
            var nextPosition = new Vector3(
                Random.Range(-GameManager.Instance.HalfWidth, GameManager.Instance.HalfWidth),
                Random.Range(0, GameManager.Instance.HalfHeight));
            
            MovePositions.Enqueue(nextPosition);
        }
        
        AddFinalPosition();
    }

    protected virtual void AddFinalPosition() { }

    private void SnapToPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void StartMoving()
    {
        _nextPosition = MovePositions.Dequeue();
        _isMoving = true;
    }

    public void StopMoving()
    {
        _isMoving = false;
    }

    public void ContinueMoving()
    {
        _isMoving = true;
    }

}