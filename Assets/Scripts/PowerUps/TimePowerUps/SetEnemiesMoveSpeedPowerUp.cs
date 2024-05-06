using System.Collections.Generic;
using System.Linq;
using Main.Enemy;

namespace PowerUps.TimePowerUps
{
    public class SetEnemiesMoveSpeedPowerUp : TimePowerUp
    {
        private readonly List<EnemySpawner> _enemySpawners;
        private readonly float _moveSpeedMultiplier;
        
        public SetEnemiesMoveSpeedPowerUp(List<EnemySpawner> enemySpawners, 
            float moveSpeedMultiplier, float duration) : base(duration)
        {
            _enemySpawners = enemySpawners;
            _moveSpeedMultiplier = moveSpeedMultiplier;
            
            Started += OnStarted;
            Finished += OnFinished;
        }
        
        private void OnStarted() =>
            SetMoveSpeed();

        private void OnFinished(TimePowerUp timePowerUp) =>
            ResetMoveSpeed();

        private void SetMoveSpeed()
        {
            foreach (var spawnedEnemy in _enemySpawners.SelectMany(enemySpawner => enemySpawner.AllEnemies))
                spawnedEnemy.Mover.SetMoveSpeed(_moveSpeedMultiplier);
        }

        private void ResetMoveSpeed()
        {
            foreach (var spawnedEnemy in _enemySpawners.SelectMany(enemySpawner => enemySpawner.AllEnemies))
                spawnedEnemy.Mover.ResetMoveSpeed();
        }
    }
}