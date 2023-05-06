using System.Collections;
using Settings;
using UnityEngine;

namespace FrogGame.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] protected EnemyPool _enemyPool;
        [Space]
        [SerializeField] private EnemySpawnerSettings _spawnerSettings;

        private Coroutine _spawnCoroutine;

        private void Start()
        {
            GameManager.Instance.GameOver += StopSpawnEnemy;
            _spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine());
        }

        private IEnumerator SpawnEnemyCoroutine()
        {
            yield return new WaitForSeconds(_spawnerSettings.FirstSpawnDelay);
        
            while (true)
            {
                yield return new WaitForSeconds(_spawnerSettings.SpawnDelay);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyPool.GetPooledObject();
            enemy.transform.position = SetSpawnPosition();
            enemy.Mover.Initialize();
        }
        
        protected virtual Vector3 SetSpawnPosition()
        {
            return Utils.RandomPositionOffTheScreen();
        }

        private void StopSpawnEnemy()
        {
            if (_spawnCoroutine == null) return;
            StopCoroutine(_spawnCoroutine);
        }
        
        private void OnDestroy()
        {
            GameManager.Instance.GameOver -= StopSpawnEnemy;
        }
    }
}

