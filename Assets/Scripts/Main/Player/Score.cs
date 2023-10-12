using System;

namespace Main.Player
{
    public class Score
    {
        public int CurrentScore { get; private set; }
        public float ScoreMultiplier { get; set; }

        public const float BaseScoreMultiplier = 1f;

        public static Action<Score> OnScoreChanged;

        public Score(int startValue = 0)
        {
            CurrentScore = startValue;
            ScoreMultiplier = BaseScoreMultiplier;
        }

        public void AddScore(int value)
        {
            var valueToAdd = (int) (value * ScoreMultiplier);
            CurrentScore += valueToAdd;
            OnScoreChanged?.Invoke(this);
        }
        
    }
}