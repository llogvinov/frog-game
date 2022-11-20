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

    private Coroutine spawnCoroutine;

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemy());

        GameManager.Instance.GameOver += StopSpawnEnemy;
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_firstSpawnDelay);
        
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            
            var enemy = _enemyPool.GetPooledObject();
            enemy.transform.position = RandomPositionOffTheScreen();
            enemy.Mover.Initialize();
        }
    }

    private void StopSpawnEnemy()
    {
        if (spawnCoroutine == null) return;
        StopCoroutine(spawnCoroutine);
    }
    
    public static Vector3 RandomPositionOffTheScreen()
    {
        var width = GameManager.Instance.HalfWidth;
        var height = GameManager.Instance.HalfHeight;
        
        return new Vector3(
            Random.Range(
                Random.Range(-width - SpriteWidth - OffScreenOffset, width), 
                Random.Range(width, width + OffScreenOffset + SpriteWidth)),
            Random.Range(height, height + OffScreenOffset + SpriteWidth));
    }

    private void OnDestroy()
    {
        GameManager.Instance.GameOver -= StopSpawnEnemy;
    }
}

