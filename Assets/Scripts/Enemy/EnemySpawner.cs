using System.Collections;
using System.Linq;
using Core;
using Settings;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] protected EnemyPool _enemyPool;
        [Space]
        [SerializeField] private EnemySpawnerSettingsGroup _spawnerSettingsGroup;

        private EnemySpawnerSettings SpawnerSettings
        {
            get
            {
                if (_spawnerSettings == null)
                {
                    _spawnerSettings = GetSpawnerSettings();
                    if (_spawnerSettings == null)
                        Debug.LogError("Spawner settings not found");
                }
                
                return _spawnerSettings;
            }
        }
        
        private EnemySpawnerSettings _spawnerSettings;
        private Coroutine _spawnCoroutine;
        private bool _active;

        private void Start()
        {
            Game.GameOver += StopSpawnEnemy;
            _enemyPool.ObjectReturned += ResetParent;
        }
        
        private void OnDestroy()
        {
            Game.GameOver -= StopSpawnEnemy;
            _enemyPool.ObjectReturned -= ResetParent;
        }

        public void Activate()
        {
            _spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine());
            _active = true;
        }

        public void ClearPool() => _enemyPool.Clear();

        private IEnumerator SpawnEnemyCoroutine()
        {
            yield return new WaitForSeconds(SpawnerSettings.FirstSpawnDelay);
        
            while (_active)
            {
                yield return new WaitForSeconds(SpawnerSettings.SpawnDelay);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var pooledObject = _enemyPool.TryGetPooledObject();
            if (pooledObject != null)
            {
                var enemy = (Enemy) pooledObject;
                enemy.transform.position = SetSpawnPosition();
                enemy.Mover.Initialize();
            }
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

        private EnemySpawnerSettings GetSpawnerSettings() =>
            _spawnerSettingsGroup.EnemySpawnerSettingsList
                .FirstOrDefault(spawnerSettings => gameObject.name.Contains(spawnerSettings.SpawningObject));

        private void ResetParent(PooledObject pooledObject) => 
            pooledObject.transform.parent = _enemyPool.transform;
    }
}

