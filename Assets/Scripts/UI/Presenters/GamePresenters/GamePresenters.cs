using Core;
using Presenters.GamePresenters;
using UnityEngine;

namespace UI.Presenters.GamePresenters
{
    public class GamePresenters : Singleton<GamePresenters>
    {
        [SerializeField] private ComboPresenter _comboPresenter;
        [SerializeField] private TimerPresenter _timerPresenter;

        public ComboPresenter ComboPresenter => _comboPresenter;
        public TimerPresenter TimerPresenter => _timerPresenter;
        
    }
}
