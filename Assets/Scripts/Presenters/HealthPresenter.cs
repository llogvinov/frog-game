using System;
using Player;
using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _healthCanvas;
        [SerializeField] private LayoutGroup _layoutGroup;
        [SerializeField] private HealthSettings _healthSettings;
        [Space]
        [SerializeField] private Image _iconPrefab;
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private Sprite _emptyHeart;

        private Image[] _icons;

        private void Awake()
        {
            _icons = new Image[_healthSettings.MaxHealth];
            
            for (int i = 0; i < _layoutGroup.transform.childCount; i++) 
                Destroy(_layoutGroup.transform.GetChild(i).gameObject);

            for (int i = 0; i < _icons.Length; i++) 
                _icons[i] = Instantiate(_iconPrefab, _layoutGroup.transform);
        }

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
            for (int i = 0; i < _icons.Length; i++)
            {
                _icons[i].sprite = healthValue > i ? _fullHeart : _emptyHeart;
            }
        }
    }
}