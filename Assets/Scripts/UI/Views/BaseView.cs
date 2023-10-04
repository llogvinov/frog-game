using UnityEngine;

namespace UI.Views
{
    public class BaseView : MonoBehaviour
    {
        [SerializeField] private Canvas _uiCanvas;

        public Canvas UICanvas => _uiCanvas;

    }
}