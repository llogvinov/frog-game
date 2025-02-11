using Main.Player.Tongue;

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
        }

        protected override void OnStarted() =>
            _tongueHead.Scale(_scaler);

        protected override void OnFinished(TimePowerUp timePowerUp) =>
            _tongueHead.ResetScale();
    }
}