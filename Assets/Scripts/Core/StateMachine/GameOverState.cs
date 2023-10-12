using System.Threading.Tasks;
using Core.AssetManagement;
using Core.AssetManagement.Loading.LocalProviders;
using Core.Factory;
using UI.Views;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameOverState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IAssetProvider _assetProvider;

        private GameOverPanelProvider _gameOverPanelProvider;

        private GameOverView GameOverView => _gameOverPanelProvider.LoadedObject.View;

        public GameOverState(GameStateMachine stateMachine, IGameFactory gameFactory, IAssetProvider assetProvider)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _assetProvider = assetProvider;
        }

        public async void Enter()
        {
            await LoadGameOverPanel();

            GameOverView.MenuButton.onClick.AddListener(LoadMenu);
            GameOverView.RestartButton.onClick.AddListener(RestartGame);
        }

        public void Exit()
        {
            _assetProvider.FrogProvider.TryUnload();
            _assetProvider.GirlProvider.TryUnload();
            
            _assetProvider.FlySpawnerProvider.TryUnload();
            _assetProvider.MosquitoSpawnerProvider.TryUnload();
            _assetProvider.DragonflySpawnerProvider.TryUnload();
            _assetProvider.WaspSpawnerProvider.TryUnload();
            _assetProvider.SpiderSpawnerProvider.TryUnload();
            
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