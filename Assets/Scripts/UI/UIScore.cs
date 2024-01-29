using Main.Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIScore : UIBase
    {
        [SerializeField] private TMP_Text _scoreText;
        
        private void Start() => 
            Score.OnScoreChanged += UpdateScoreUI;

        private void OnDestroy() => 
            Score.OnScoreChanged -= UpdateScoreUI;

        public void Init()
        {
            Show();
            UpdateScoreText(0);
        }

        private void UpdateScoreUI(Score score) 
            => UpdateScoreText(score.CurrentScore);

        private void UpdateScoreText(int scoreValue) 
            => _scoreText.text = scoreValue.ToString();
    }
}