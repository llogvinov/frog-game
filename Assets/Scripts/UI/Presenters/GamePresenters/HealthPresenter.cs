using Main.Player;
using Settings;
using UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters.GamePresenters
{
    [RequireComponent(typeof(HealthView))]
    public class HealthPresenter : BasePresenter
    {
        [SerializeField] private HealthSettings _healthSettings;
        [Space]
        [SerializeField] private Image _iconPrefab;
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private Sprite _emptyHeart;
        
        private HealthView _healthView;
        private Image[] _icons;

        protected override void Awake()
        {
            _healthView = GetComponent<HealthView>();
            _icons = new Image[_healthSettings.MaxHealth];

            PrepareLayoutGroup();

            void PrepareLayoutGroup()
            {
                ClearLayoutGroup();
                FillLayoutGroup();

                void ClearLayoutGroup()
                {
                    for (int i = 0; i < _healthView.Group.transform.childCount; i++)
                        Destroy(_healthView.Group.transform.GetChild(i).gameObject);
                }

                void FillLayoutGroup()
                {
                    for (int i = 0; i < _icons.Length; i++)
                        _icons[i] = Instantiate(_iconPrefab, _healthView.Group.transform);
                }
            }
        }

        private void Start() => 
            Health.OnHealthChanged += UpdateHealthUI;

        private void OnDestroy() => 
            Health.OnHealthChanged -= UpdateHealthUI;

        public void Init() => 
            UpdateHealthIcons(_healthSettings.MaxHealth);

        private void UpdateHealthUI(Health health) 
            => UpdateHealthIcons(health.CurrentHealth);

        private void UpdateHealthIcons(int healthValue)
        {
            for (var i = 0; i < _icons.Length; i++) 
                _icons[i].sprite = healthValue > i ? _fullHeart : _emptyHeart;
        }
    }
}