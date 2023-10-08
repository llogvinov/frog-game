using System;

namespace PowerUps.ActivatedPowerUps
{
    public abstract class ActivatedPowerUp : IPowerUp
    {
        public Action Applied;
        
        public abstract void Apply();
    }
}
