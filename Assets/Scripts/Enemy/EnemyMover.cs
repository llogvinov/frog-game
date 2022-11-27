using System;
using System.Collections.Generic;
using FrogGame;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EnemyMover : BasePathMover
{
    [SerializeField] private uint _movePositionNumber;
    
    private bool _isFacingRight;

    protected uint MovePositionNumber => _movePositionNumber;

    public void Initialize()
    {
        SetPositions();
        MoveToNextPosition();
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
        MoveToNextPosition();
    }

}