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
            
            Start += OnStart;
            Finish += OnFinish;
        }

        private void OnStart() =>
            _tongueHead.Scale(_scaler);

        private void OnFinish() =>
            _tongueHead.ResetScale();

        ~TongueHeadScalerPowerUp()
        {
            Start -= OnStart;
            Finish -= OnFinish;
        }
    }
}