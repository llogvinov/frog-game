using System.Collections.Generic;
using Main.Enemy;

namespace PowerUps.ActivatedPowerUps
{
    public class FreezeEnemiesPowerUp : ActivatedPowerUp
    {
        private readonly List<EnemySpawner> _enemySpawners;

        public FreezeEnemiesPowerUp(List<EnemySpawner> enemySpawners)
        {
            _enemySpawners = enemySpawners;
        }
        
        public override void Apply()
        {
            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Pause();
                foreach (var spawnedEnemy in enemySpawner.SpawnedEnemies)
                {
                    spawnedEnemy.Mover.ForceStopMoving();
                }
            }

            Applied?.Invoke();
        }
    }
    
    public class UnFreezeEnemiesPowerUp : ActivatedPowerUp
    {
        private readonly List<EnemySpawner> _enemySpawners;

        public UnFreezeEnemiesPowerUp(List<EnemySpawner> enemySpawners)
        {
            _enemySpawners = enemySpawners;
        }
        
        public override void Apply()
        {
            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Continue();
                foreach (var spawnedEnemy in enemySpawner.SpawnedEnemies)
                {
                    spawnedEnemy.Mover.ContinueMoving();
                }
            }

            Applied?.Invoke();
        }
    }
}