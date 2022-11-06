using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMover : MonoBehaviour, IMovable
{
    [SerializeField] private uint _movePositionNumber;
    [SerializeField] private float _speed;

    private Queue<Vector3> _movePositions;
    private Vector3 _nextPosition;
    private bool _isMoving;

    private void Update()
    {
        if (_isMoving)
        {
            Move(Time.deltaTime);
        }
    }

    public void Move(float t)
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _speed * t);
        
        if ((_nextPosition - transform.position).sqrMagnitude < 0.001f)
        {
            SnapToPosition(_nextPosition);

            if (_movePositions.Count > 0)
            {
                _nextPosition = _movePositions.Dequeue();
            }
            else
            {
                _isMoving = false;
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
        _movePositions = new Queue<Vector3>();
        var halfWidth = Screen.width / 2 / 100f;
        var halfHeight = Screen.height / 2 / 100f;

        for (int i = 0; i < _movePositionNumber; i++)
        {
            var nextPosition = new Vector3(
                Random.Range(-halfWidth, halfWidth),
                Random.Range(0, halfHeight));
            
            _movePositions.Enqueue(nextPosition);
        }
        
        AddFinalPosition();
    }

    protected virtual void AddFinalPosition()
    {
        // frog girl for eatable, spawn point for damageable
    }

    private void SnapToPosition(Vector2 position)
    {
        transform.position = position;
    }

    private void StartMoving()
    {
        _nextPosition = _movePositions.Dequeue();
        _isMoving = true;
    }
    
}