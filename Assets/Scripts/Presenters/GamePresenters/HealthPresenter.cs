using Player;
using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters.GamePresenters
{
    public class HealthPresenter : BasePresenter
    {
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
            Health.OnHealthChanged += UpdateHealthUI;
        }

        private void OnDestroy()
        {
            Health.OnHealthChanged -= UpdateHealthUI;
        }

        public void Init()
        {
            UpdateHealthIcons(_healthSettings.MaxHealth);
        }

        private void UpdateHealthUI(Health health) 
            => UpdateHealthIcons(health.CurrentHealth);

        private void UpdateHealthIcons(int healthValue)
        {
            for (var i = 0; i < _icons.Length; i++) 
                _icons[i].sprite = healthValue > i ? _fullHeart : _emptyHeart;
        }
    }
}