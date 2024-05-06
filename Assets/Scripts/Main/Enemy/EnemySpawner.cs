using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Pooling;
using Settings;
using UnityEngine;

namespace Main.Enemy
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

        public List<Enemy> SpawnedEnemies => _spawnedEnemies;
        public List<Enemy> AllEnemies => _allEnemies;

        private EnemySpawnerSettings _spawnerSettings;
        private Coroutine _spawnCoroutine;
        private bool _active;

        private List<Enemy> _spawnedEnemies;
        private List<Enemy> _allEnemies;

        private void Start()
        {
            Game.GameOver += StopSpawnEnemy;
            _enemyPool.ObjectReturned += ResetEnemy;
            SetAllEnemiesList();
            _spawnedEnemies = new List<Enemy>();
        }
        
        private void OnDestroy()
        {
            Game.GameOver -= StopSpawnEnemy;
            _enemyPool.ObjectReturned -= ResetEnemy;
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
            if (!_active) return;
            
            var pooledObject = _enemyPool.TryGetPooledObject();
            if (pooledObject != null)
            {
                var enemy = (Enemy) pooledObject;
                _spawnedEnemies.Add(enemy);
                enemy.transform.position = SetSpawnPosition();
                enemy.Mover.Initialize();
            }
        }

        private void SetAllEnemiesList()
        {
            _allEnemies = new List<Enemy>();
            foreach (var instance in _enemyPool.AllInstances)
            {
                var enemy = (Enemy) instance;
                _allEnemies.Add(enemy);
            }
        }
        
        protected virtual Vector3 SetSpawnPosition()
        {
            return Utils.RandomPositionOffTheScreen();
        }

        public void Pause() => _active = false;
        public void Continue() => _active = true;

        private void StopSpawnEnemy()
        {
            if (_spawnCoroutine == null) return;
            
            StopCoroutine(_spawnCoroutine);
            _active = false;
        }

        private EnemySpawnerSettings GetSpawnerSettings() =>
            _spawnerSettingsGroup.EnemySpawnerSettingsList
                .FirstOrDefault(spawnerSettings => gameObject.name.Contains(spawnerSettings.SpawningObject));

        private void ResetEnemy(PooledObject pooledObject)
        {
            var enemy = (Enemy) pooledObject;
            _spawnedEnemies.Remove(enemy);
            pooledObject.transform.parent = _enemyPool.transform;
            pooledObject.transform.localScale = Vector3.one;
        }
    }
}

