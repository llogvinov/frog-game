using UI.Views;
using UnityEngine;

namespace UI.Presenters
{
    [RequireComponent(typeof(LoadingScreenView))]
    public class LoadingScreenPresenter : BasePresenter
    {
        protected override void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}