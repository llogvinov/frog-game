using System.Threading.Tasks;
using Core.AssetManagement;
using Core.Factory;
using Core.Loading.LocalProviders;
using UI.Views;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameOverState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        private GameOverPanelProvider _gameOverPanelProvider;

        private GameOverView GameOverView => _gameOverPanelProvider.LoadedObject.View;

        public GameOverState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public async void Enter()
        {
            await LoadGameOverPanel();

            GameOverView.MenuButton.onClick.AddListener(LoadMenu);
            GameOverView.RestartButton.onClick.AddListener(RestartGame);
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
            
            GameOverView.MenuButton.onClick.RemoveListener(LoadMenu);
            GameOverView.RestartButton.onClick.RemoveListener(RestartGame);
            _gameOverPanelProvider.TryUnload();
        }

        private async Task LoadGameOverPanel()
        {
            _gameOverPanelProvider = new GameOverPanelProvider();
            var loadTask = _gameOverPanelProvider.Load();
            await loadTask;
        }

        private void LoadMenu() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.MenuScene);

        private void RestartGame() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
    }
}