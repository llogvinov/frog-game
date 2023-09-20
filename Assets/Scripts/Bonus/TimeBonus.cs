using System.Threading.Tasks;

namespace Bonus
{
    public abstract class TimeBonus
    {
        public delegate void TimeBonusEvents(TimeBonus bonus);

        public event TimeBonusEvents BonusStarted;
        public event TimeBonusEvents BonusStopped;

        protected float Duration;

        public TimeBonus(float duration)
        {
            Duration = duration;
        }

        public virtual async Task ActivateBonus()
        {
            await ProcessBonus();
        }

        public virtual void StartBonus()
        {
            BonusStarted?.Invoke(this);
        }

        protected virtual async Task ProcessBonus()
        {
            StartBonus();
            await Task.Delay((int)(Duration * 1000));
            StopBonus();
        }

        public virtual void StopBonus()
        {
            BonusStopped?.Invoke(this);
        }
    }
}
