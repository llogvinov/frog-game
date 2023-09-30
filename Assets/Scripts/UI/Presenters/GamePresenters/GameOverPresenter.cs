using UI.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters.GamePresenters
{
    public class GameOverPresenter : BasePresenter
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;

        public Button MenuButton => _menuButton;

        public Button RestartButton => _restartButton;
    }
}