using Core;
using UnityEngine;

namespace Main.Enemy.Damageable
{
    public class SpiderSpawner : EnemySpawner
    {
        protected override Vector3 SetSpawnPosition()
        {
            return Utils.RandomPositionOverTopOfScreen();
        }
    }
}