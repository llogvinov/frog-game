using System.Threading.Tasks;
using Core.AssetManagement;
using Core.Factory;
using Core.Loading;
using Core.Loading.LocalProviders;
using UI.Presenters.GamePresenters;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameOverState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        private PanelProvider<GameOverPanelProvider, GameOverPresenter> _gameOverPanelProvider;

        private GameOverPresenter GameOverPresenter => _gameOverPanelProvider.Presenter;

        public GameOverState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public async void Enter()
        {
            await LoadGameOverPanel();

            GameOverPresenter.MenuButton.onClick.AddListener(LoadMenu);
            GameOverPresenter.RestartButton.onClick.AddListener(RestartGame);
        }

        public void Exit()
        {
            Object.Destroy(_gameFactory.Player.gameObject);
            Object.Destroy(_gameFactory.FrogGirl.gameObject);

            foreach (var spawner in _gameFactory.EnemySpawners)
            {
                spawner.ClearPool();
                Object.Destroy(spawner.gameObject);
            }
            
            GameOverPresenter.MenuButton.onClick.RemoveListener(LoadMenu);
            GameOverPresenter.RestartButton.onClick.RemoveListener(RestartGame);
            _gameOverPanelProvider.Unload();
        }

        private async Task LoadGameOverPanel()
        {
            _gameOverPanelProvider = new PanelProvider<GameOverPanelProvider, GameOverPresenter>
                (new GameOverPanelProvider());
            var loadTask = _gameOverPanelProvider.Load();
            await loadTask;
        }

        private void LoadMenu() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.MenuScene);

        private void RestartGame() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
    }
}