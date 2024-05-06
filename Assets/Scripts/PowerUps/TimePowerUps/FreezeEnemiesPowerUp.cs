using System.Collections.Generic;
using Main.Enemy;

namespace PowerUps.TimePowerUps
{
    public class FreezeEnemiesPowerUp : TimePowerUp
    {
        private readonly List<EnemySpawner> _enemySpawners;

        public FreezeEnemiesPowerUp(List<EnemySpawner> enemySpawners, float duration) 
            : base(duration)
        {
            _enemySpawners = enemySpawners;
            
            Started += OnStarted;
            Finished += OnFinished;
        }

        private void OnStarted() =>
            FreezeEnemies();

        private void OnFinished(TimePowerUp timePowerUp) =>
            UnFreezeEnemies();

        private void FreezeEnemies()
        {
            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Pause();
                foreach (var spawnedEnemy in enemySpawner.SpawnedEnemies)
                {
                    spawnedEnemy.Mover.ForceStopMoving();
                }
            }
        }
        
        private void UnFreezeEnemies()
        {
            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Continue();
                foreach (var spawnedEnemy in enemySpawner.SpawnedEnemies)
                {
                    spawnedEnemy.Mover.ContinueMoving();
                }
            }
        }

        ~FreezeEnemiesPowerUp()
        {
            Started -= OnStarted;
            Finished -= OnFinished;
        }
    }
}