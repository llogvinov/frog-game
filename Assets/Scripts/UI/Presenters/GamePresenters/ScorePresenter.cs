using Main.Player;
using UI.Views;
using UnityEngine;

namespace UI.Presenters.GamePresenters
{
    [RequireComponent(typeof(ScoreView))]
    public class ScorePresenter : BasePresenter
    {
        private ScoreView _scoreView;

        protected override void Awake()
        {
            base.Awake();
            _scoreView = GetComponent<ScoreView>();
        }

        private void Start() => 
            Score.OnScoreChanged += UpdateScoreUI;

        private void OnDestroy() => 
            Score.OnScoreChanged -= UpdateScoreUI;

        public void Init() => 
            UpdateScoreText(0);

        private void UpdateScoreUI(Score score) 
            => UpdateScoreText(score.CurrentScore);

        private void UpdateScoreText(int scoreValue) 
            => _scoreView.ScoreText.text = scoreValue.ToString();
    }
}