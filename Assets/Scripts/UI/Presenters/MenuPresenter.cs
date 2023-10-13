using UI.Views;
using UnityEngine;

namespace UI.Presenters
{
    [RequireComponent(typeof(MenuView))]
    public class MenuPresenter : BasePresenter
    {
        private MenuView _menuView;

        public MenuView View => _menuView;

        protected override void Awake()
        {
            base.Awake();
            _menuView = GetComponent<MenuView>();
        }
    }
}