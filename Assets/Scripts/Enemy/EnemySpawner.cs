using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [Space] 
    [SerializeField] private float _firstSpawnDelay;
    [SerializeField] private float _spawnDelay;

    private const float SpriteWidth = 1f;
    private const float OffScreenOffset = 2f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_firstSpawnDelay);
        
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = _enemyPool.GetPooledObject();
        enemy.transform.position = RandomPositionOffTheScreen();
        enemy.Mover.Initialize();
    }
    
    public static Vector2 RandomPositionOffTheScreen()
    {
        var width = GameManager.Instance.HalfWidth;
        var height = GameManager.Instance.HalfHeight;
        
        return new Vector2(
            Random.Range(
                Random.Range(-width - SpriteWidth - OffScreenOffset, width), 
                Random.Range(width, width + OffScreenOffset + SpriteWidth)),
            Random.Range(height, height + OffScreenOffset + SpriteWidth));
    }
    
}

