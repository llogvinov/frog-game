using PowerUps;
using PowerUps.ActivatedPowerUps;
using PowerUps.TimePowerUps;
using UnityEngine;

namespace Main.Enemy.Eatable
{
    public class PowerUpEnemy : MonoBehaviour
    {
        public async void DoPowerUp(IPowerUp powerUp)
        {
            switch (powerUp)
            {
                case TimePowerUp timePowerUp:
                    await timePowerUp.Activate();
                    break;
                case ActivatedPowerUp activatedPowerUp:
                    activatedPowerUp.Apply();
                    break;
            }
        }
    }
}