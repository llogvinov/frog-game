using Tongue;

namespace PowerUps.TimePowerUps
{
    public class TongueHeadScalerPowerUp : TimePowerUp
    {
        private readonly TongueHead _tongueHead;
        private readonly float _scaler;
        
        public TongueHeadScalerPowerUp(TongueHead tongueHead, float scaler, float duration) 
            : base(duration)
        {
            _tongueHead = tongueHead;
            _scaler = scaler;
            
            Started += OnStarted;
            Finished += OnFinished;
        }

        private void OnStarted() =>
            _tongueHead.Scale(_scaler);

        private void OnFinished(TimePowerUp timePowerUp) =>
            _tongueHead.ResetScale();

        ~TongueHeadScalerPowerUp()
        {
            Started -= OnStarted;
            Finished -= OnFinished;
        }
    }
}