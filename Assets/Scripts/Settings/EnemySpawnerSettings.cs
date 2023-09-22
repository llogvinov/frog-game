using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemySpawnerSettings", menuName = "ObjectSettings/EnemySpawnerSettings")]
    public class EnemySpawnerSettings : ScriptableObject
    {
        [SerializeField] private float _firstSpawnDelay;
        [SerializeField] private float _spawnDelay;
        
        public float FirstSpawnDelay => _firstSpawnDelay;
        public float SpawnDelay => _spawnDelay;
    }
}