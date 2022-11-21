using UnityEngine;

namespace FrogGame
{
    public class GameOverPresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _gameOverCanvas;
        
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
            _gameOverCanvas.gameObject.SetActive(true);
        }
    }
}