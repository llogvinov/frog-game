using UnityEngine;

namespace FrogGame.Enemy
{
    public class SpiderSpawner : EnemySpawner
    {
        protected override Vector3 SetSpawnPosition()
        {
            return Utils.RandomPositionOverTopOfScreen();
        }
    }
}