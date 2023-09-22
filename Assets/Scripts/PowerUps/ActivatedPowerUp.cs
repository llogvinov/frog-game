using System;

namespace PowerUps
{
    public abstract class ActivatedPowerUp
    {
        public Action Applied;
        
        public abstract void Apply();
    }
}
