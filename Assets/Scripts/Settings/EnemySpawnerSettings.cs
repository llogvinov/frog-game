using UnityEngine;

namespace Settings
{
    public class EnemySpawnerSettings : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _firstSpawnDelay;
        [SerializeField] private float _spawnDelay;
        
        public float FirstSpawnDelay => _firstSpawnDelay;
        public float SpawnDelay => _spawnDelay;
        
        public void Init(string spawnerName, float firstSpawnDelay, float spawnDelay)
        {
            _name = spawnerName;
            _firstSpawnDelay = firstSpawnDelay;
            _spawnDelay = spawnDelay;
        }
    }
}