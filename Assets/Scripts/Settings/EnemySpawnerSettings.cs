using UnityEngine;

namespace Settings
{
    public class EnemySpawnerSettings : ScriptableObject
    {
        [SerializeField] private string _spawningObject;
        [SerializeField] private float _firstSpawnDelay;
        [SerializeField] private float _spawnDelay;
        
        public float FirstSpawnDelay => _firstSpawnDelay;
        public float SpawnDelay => _spawnDelay;
        public string SpawningObject => _spawningObject;

        public void Init(string spawnerName, float firstSpawnDelay, float spawnDelay)
        {
            _spawningObject = spawnerName;
            _firstSpawnDelay = firstSpawnDelay;
            _spawnDelay = spawnDelay;
        }
    }
}