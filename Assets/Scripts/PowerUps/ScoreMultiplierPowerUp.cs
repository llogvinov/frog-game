using Player;

namespace PowerUps
{
    public class ScoreMultiplierPowerUp : TimePowerUp
    {
        private readonly Score _score;
        private readonly float _multiplier;

        public ScoreMultiplierPowerUp(Score score, float multiplier, float duration) : base(duration)
        {
            _score = score;
            _multiplier = multiplier;
            
            Start += OnStart;
            Finish += OnFinish;
        }

        private void OnStart() => 
            _score.ScoreMultiplier = _multiplier;

        private void OnFinish() =>
            _score.ScoreMultiplier = Score.BaseScoreMultiplier;

        ~ScoreMultiplierPowerUp()
        {
            Start -= OnStart;
            Finish -= OnFinish;
        }
    }
}