namespace FrogGame
{
    public class Score
    {
        public int CurrentScore { get; private set; }
        public ScorePresenter ScorePresenter { get; }

        public Score(ScorePresenter scorePresenter, int startValue = 0)
        {
            ScorePresenter = scorePresenter;
            CurrentScore = startValue;
        }

        public void AddScore(int value)
        {
            CurrentScore += value;
            ScorePresenter.UpdateScoreText(this);
        }
        
    }
}