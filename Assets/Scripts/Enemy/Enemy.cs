using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;
    
    private EnemyPool _pool;

    public EnemyPool Pool
    {
        get => _pool;
        set => _pool = value;
    }

    public EnemyMover Mover => _mover;

    public void Release()
    {
        _pool.ReturnToPool(this);
    }
}