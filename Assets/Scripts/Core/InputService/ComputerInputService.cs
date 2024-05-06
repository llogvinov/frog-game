using Core.Factory;
using PowerUps.ActivatedPowerUps;
using UnityEngine;

namespace Core.InputService
{
    public class ComputerInputService : InputService
    {
        protected override void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                OnHitSet(Camera.ScreenToWorldPoint(mousePosition));
                OnInputDone();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                var freezeEnemiesPowerUp = new FreezeEnemiesPowerUp(AllServices.Container.Single<IGameFactory>().EnemySpawners);
                freezeEnemiesPowerUp.Apply();
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                var unfreezeEnemiesPowerUp = new UnFreezeEnemiesPowerUp(AllServices.Container.Single<IGameFactory>().EnemySpawners);
                unfreezeEnemiesPowerUp.Apply();
            }
        }
    }
}