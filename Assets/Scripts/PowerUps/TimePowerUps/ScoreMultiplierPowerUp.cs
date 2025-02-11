using Main.Player;

namespace PowerUps.TimePowerUps
{
    public class ScoreMultiplierPowerUp : TimePowerUp
    {
        private readonly Score _score;
        private readonly float _multiplier;

        public ScoreMultiplierPowerUp(Score score, float multiplier, float duration) 
            : base(duration)
        {
            _score = score;
            _multiplier = multiplier;
        }

        protected override void OnStarted() => 
            _score.ScoreMultiplier = _multiplier;

        protected override void OnFinished(TimePowerUp timePowerUp) =>
            _score.ScoreMultiplier = Score.BaseScoreMultiplier;
    }
}