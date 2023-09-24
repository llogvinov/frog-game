using System.Collections;
using Core;
using Settings;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] protected EnemyPool _enemyPool;
        [Space]
        [SerializeField] private EnemySpawnerSettings _spawnerSettings;

        private Coroutine _spawnCoroutine;
        private bool _active;

        private void Start()
        {
            Game.GameOver += StopSpawnEnemy;
        }
        
        private void OnDestroy()
        {
            Game.GameOver -= StopSpawnEnemy;
        }

        public void Activate()
        {
            _spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine());
            _active = true;
        }

        public void ClearPool() => _enemyPool.Clear();

        private IEnumerator SpawnEnemyCoroutine()
        {
            yield return new WaitForSeconds(_spawnerSettings.FirstSpawnDelay);
        
            while (_active)
            {
                yield return new WaitForSeconds(_spawnerSettings.SpawnDelay);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var enemy = (Enemy) _enemyPool.GetPooledObject();
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
            _active = false;
        }

        public void SetSpawnerSettings(EnemySpawnerSettings spawnerSettings)
        {
            _spawnerSettings = spawnerSettings;
        }
    }
}

