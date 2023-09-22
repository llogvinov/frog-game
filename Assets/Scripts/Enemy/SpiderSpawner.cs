using Core;
using UnityEngine;

namespace Enemy
{
    public class SpiderSpawner : EnemySpawner
    {
        protected override Vector3 SetSpawnPosition()
        {
            return Utils.RandomPositionOverTopOfScreen();
        }
    }
}