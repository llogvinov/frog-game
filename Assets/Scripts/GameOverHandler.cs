using UnityEngine;

namespace FrogGame
{
    public class GameOverHandler : MonoBehaviour
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
            Debug.Log("game over");
            _gameOverCanvas.gameObject.SetActive(true);
        }
    }
}