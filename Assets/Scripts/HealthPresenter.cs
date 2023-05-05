using Player;
using UnityEngine;
using UnityEngine.UI;

namespace FrogGame
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _healthCanvas;
        [SerializeField] private LayoutGroup _layoutGroup;

        private void Start()
        {
            GameManager.Instance.GameOver += OnGameOver;
            Health.OnHealthChanged += UpdateHealthUI;
        }

        private void OnDestroy()
        {
            GameManager.Instance.GameOver -= OnGameOver;
            Health.OnHealthChanged -= UpdateHealthUI;
        }

        private void OnGameOver()
        {
            _healthCanvas.gameObject.SetActive(false);
        }

        private void UpdateHealthUI(Health health)
        {
            var healthValue = health.CurrentHealth;
            
        }
    }
}