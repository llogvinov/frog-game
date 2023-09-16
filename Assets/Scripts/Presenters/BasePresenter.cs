using UnityEngine;

namespace Presenters
{
    public class BasePresenter : MonoBehaviour
    {
        [SerializeField] private Canvas _uiCanvas;

        protected Canvas UICanvas => _uiCanvas;

        public void Switch(bool enable) => _uiCanvas.gameObject.SetActive(enable);
    }
}