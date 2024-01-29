using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIHealth _uiHealth;
        [SerializeField] private UIScore _uiScore;
        [SerializeField] private UICombo _uiCombo;
        [SerializeField] private UIGameOver _uiGameOver;

        public UIHealth UIHealth => _uiHealth;

        public UIScore UIScore => _uiScore;

        public UICombo UICombo => _uiCombo;

        public UIGameOver UIGameOver => _uiGameOver;
    }
}