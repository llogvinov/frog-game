using TMPro;
using UnityEngine;

namespace FrogGame
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _scoreCanvas;
        [SerializeField] private TMP_Text _scoreText;

        private void Start()
        {
            GameManager.Instance.GameOver += OnGameOver;
            Score.OnScoreChanged += UpdateScoreText;
        }

        private void OnDestroy()
        {
            GameManager.Instance.GameOver -= OnGameOver;
            Score.OnScoreChanged -= UpdateScoreText;
        }

        private void OnGameOver()
        {
            _scoreCanvas.gameObject.SetActive(false);
        }

        private void UpdateScoreText(Score score)
        {
            _scoreText.text = score.CurrentScore.ToString();
        }
    }
}