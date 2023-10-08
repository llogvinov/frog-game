using System;
using System.Threading.Tasks;

namespace PowerUps.TimePowerUps
{
    public abstract class TimePowerUp : IPowerUp
    {
        public static event Action<TimePowerUp, float> AnyTimePowerUpStarted;
        
        public event Action Started;
        public event Action<TimePowerUp> Finished;
        
        protected readonly float Duration;

        protected TimePowerUp(float duration)
        {
            Duration = duration;
        }

        public async Task Activate()
        {
            AnyTimePowerUpStarted?.Invoke(this, Duration);
            Started?.Invoke();
            await Task.Delay((int) (Duration * 1000));
            Finished?.Invoke(this);
        }
    }
}