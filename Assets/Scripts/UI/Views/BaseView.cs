using UnityEngine;

namespace UI.Views
{
    public class BaseView : MonoBehaviour
    {
        [SerializeField] private Canvas _uiCanvas;

        protected Canvas UICanvas => _uiCanvas;

    }
}