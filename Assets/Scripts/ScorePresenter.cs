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
        }

        private void OnDestroy()
        {
            GameManager.Instance.GameOver -= OnGameOver;
        }

        private void OnGameOver()
        {
            _scoreCanvas.gameObject.SetActive(false);
        }

        public void UpdateScoreText(Score score)
        {
            _scoreText.text = score.CurrentScore.ToString();
        }
    }
}