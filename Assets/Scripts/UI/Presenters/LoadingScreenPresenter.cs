using UI.Views;
using UnityEngine;

namespace UI.Presenters
{
    [RequireComponent(typeof(LoadingScreenView))]
    public class LoadingScreenPresenter : BasePresenter
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}