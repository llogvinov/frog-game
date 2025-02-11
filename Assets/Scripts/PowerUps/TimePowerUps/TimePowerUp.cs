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

        public TimePowerUp(float duration)
        {
            Duration = duration;

            Started += OnStarted;
            Finished += OnFinished;
        }

        protected abstract void OnStarted();
        protected abstract void OnFinished(TimePowerUp powerUp);

        public async Task Activate()
        {
            AnyTimePowerUpStarted?.Invoke(this, Duration);
            Started?.Invoke();
            await Task.Delay((int) (Duration * 1000));
            Finished?.Invoke(this);
        }
        
        ~TimePowerUp()
        {
            Started -= OnStarted;
            Finished -= OnFinished;
        }
    }
}