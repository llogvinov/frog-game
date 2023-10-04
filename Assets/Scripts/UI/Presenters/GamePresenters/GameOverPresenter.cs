using UI.Views;
using UnityEngine;

namespace UI.Presenters.GamePresenters
{
    [RequireComponent(typeof(GameOverView))]
    public class GameOverPresenter : BasePresenter
    {
        private GameOverView _gameOverView;

        public GameOverView View => _gameOverView;

        protected override void Awake()
        {
            base.Awake();
            _gameOverView = GetComponent<GameOverView>();
        }
    }
}