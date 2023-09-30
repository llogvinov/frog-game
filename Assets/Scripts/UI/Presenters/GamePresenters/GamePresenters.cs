using Core;
using UnityEngine;

namespace Presenters.GamePresenters
{
    public class GamePresenters : Singleton<GamePresenters>
    {
        [SerializeField] private HealthPresenter _healthPresenter;
        [SerializeField] private ScorePresenter _scorePresenter;
        [SerializeField] private ComboPresenter _comboPresenter;
        [SerializeField] private TimerPresenter _timerPresenter;

        public HealthPresenter HealthPresenter => _healthPresenter;
        public ScorePresenter ScorePresenter => _scorePresenter;
        public ComboPresenter ComboPresenter => _comboPresenter;
        public TimerPresenter TimerPresenter => _timerPresenter;
        
    }
}
