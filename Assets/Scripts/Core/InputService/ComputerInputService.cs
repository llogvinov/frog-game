using Core.Factory;
using PowerUps.TimePowerUps;
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
                var freezeEnemiesPowerUp = new FreezeEnemiesPowerUp(AllServices.Container.Single<IGameFactory>().EnemySpawners, 2f);
                freezeEnemiesPowerUp.Activate();
            }
        }
    }
}