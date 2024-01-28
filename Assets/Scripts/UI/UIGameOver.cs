using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIGameOver : UIBase
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;

        public Button MenuButton => _menuButton;

        public Button RestartButton => _restartButton;
    }
}