using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private EnemyPool _pool;

    public EnemyPool Pool
    {
        get => _pool;
        set => _pool = value;
    }

    public void Release()
    {
        _pool.ReturnToPool(this);
    }
}