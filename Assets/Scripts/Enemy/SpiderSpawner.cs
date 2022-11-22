using UnityEngine;

namespace FrogGame.Enemy
{
    public class SpiderSpawner : EnemySpawner
    {
        protected override void SpawnEnemy()
        {
            var enemy = _enemyPool.GetPooledObject();
            enemy.transform.position = SetSpawnPosition();
            enemy.Mover.Initialize();
        }

        private Vector3 SetSpawnPosition()
        {
            var width = GameManager.Instance.HalfWidth;
            var height = GameManager.Instance.HalfHeight;
        
            return new Vector3(
                Random.Range(-width, width),
                Random.Range(height, height + OffScreenOffset + SpriteWidth));
        }
    }
}