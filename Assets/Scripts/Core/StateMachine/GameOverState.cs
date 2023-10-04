using System.Threading.Tasks;
using Core.AssetManagement;
using Core.Factory;
using Core.Loading.LocalProviders;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameOverState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        private GameOverPanelProvider _gameOverPanelProvider;

        public GameOverState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public async void Enter()
        {
            await LoadGameOverPanel();

            _gameOverPanelProvider.LoadedObject.MenuButton.onClick.AddListener(LoadMenu);
            _gameOverPanelProvider.LoadedObject.RestartButton.onClick.AddListener(RestartGame);
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
            
            _gameOverPanelProvider.LoadedObject.MenuButton.onClick.RemoveListener(LoadMenu);
            _gameOverPanelProvider.LoadedObject.RestartButton.onClick.RemoveListener(RestartGame);
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