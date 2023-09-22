using System;
using System.Threading.Tasks;

namespace PowerUps
{
    public abstract class TimePowerUp
    {
        public Action Start;
        public Action Finish;
        
        protected readonly float Duration;

        protected TimePowerUp(float duration)
        {
            Duration = duration;
        }

        public async Task Activate()
        {
            Start?.Invoke();
            await Task.Delay((int) (Duration * 1000));
            Finish?.Invoke();
        }
    }
}