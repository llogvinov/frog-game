using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected EnemyPool _enemyPool;
    [Space] 
    [SerializeField] private float _firstSpawnDelay;
    [SerializeField] private float _spawnDelay;

    protected const float SpriteWidth = 1f;
    protected const float OffScreenOffset = 2f;

    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine());

        GameManager.Instance.GameOver += StopSpawnEnemy;
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        yield return new WaitForSeconds(_firstSpawnDelay);
        
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            SpawnEnemy();
        }
    }

    protected virtual void SpawnEnemy()
    {
        var enemy = _enemyPool.GetPooledObject();
        enemy.transform.position = RandomPositionOffTheScreen();
        enemy.Mover.Initialize();
    }

    private void StopSpawnEnemy()
    {
        if (_spawnCoroutine == null) return;
        StopCoroutine(_spawnCoroutine);
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

