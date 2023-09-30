using System.Threading.Tasks;
using Core.AssetManagement;
using Core.Factory;
using Core.Loading.LocalProviders;
using Presenters.GamePresenters;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameOverState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        private GameOverPanelProvider _gameOverPanelProvider;
        private GameOverPresenter _gameOverPresenter;

        public GameOverState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public async void Enter()
        {
            await LoadGameOverPanel();

            _gameOverPresenter.MenuButton.onClick.AddListener(LoadMenu);
            _gameOverPresenter.RestartButton.onClick.AddListener(RestartGame);
            
            Object.Destroy(_gameFactory.Player.gameObject);
            Object.Destroy(_gameFactory.FrogGirl.gameObject);

            foreach (var spawner in _gameFactory.EnemySpawners)
            {
                spawner.ClearPool();
                Object.Destroy(spawner.gameObject);
            }
        }

        public void Exit()
        {
            _gameOverPresenter.MenuButton.onClick.RemoveListener(LoadMenu);
            _gameOverPresenter.RestartButton.onClick.RemoveListener(RestartGame);
            _gameOverPanelProvider.Unload();
        }

        private async Task LoadGameOverPanel()
        {
            _gameOverPanelProvider = new GameOverPanelProvider();
            _gameOverPresenter = await _gameOverPanelProvider.Load();
        }

        private void LoadMenu() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.MenuScene);

        private void RestartGame() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
    }
}