using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        var enemy = _enemyPool.GetPooledObject();
        enemy.Mover.Initialize();
    } 
}

