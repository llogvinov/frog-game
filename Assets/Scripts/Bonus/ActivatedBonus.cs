using System;

namespace Bonus
{
    public abstract class ActivatedBonus
    {
        public Action Applied;
        
        public abstract void Apply();
    }
}
