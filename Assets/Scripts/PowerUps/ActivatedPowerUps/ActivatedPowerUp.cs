using System;

namespace PowerUps.ActivatedPowerUps
{
    public abstract class ActivatedPowerUp
    {
        public Action Applied;
        
        public abstract void Apply();
    }
}
