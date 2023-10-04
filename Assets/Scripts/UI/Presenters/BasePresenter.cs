using UI.Views;
using UnityEngine;

namespace UI.Presenters
{
    [RequireComponent(typeof(BaseView))]
    public class BasePresenter : MonoBehaviour
    {
        private BaseView _baseView;
        
        protected virtual void Awake() => 
            _baseView = GetComponent<BaseView>();

        public void Switch(bool enable) => 
            _baseView.UICanvas.gameObject.SetActive(enable);
    }
}