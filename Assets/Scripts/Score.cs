using System;

namespace FrogGame
{
    public class Score
    {
        public int CurrentScore { get; private set; }

        public static Action<Score> OnScoreChanged;

        public Score(int startValue = 0)
        {
            CurrentScore = startValue;
        }

        public void AddScore(int value)
        {
            CurrentScore += value;
            OnScoreChanged?.Invoke(this);
        }
        
    }
}