using System.Threading.Tasks;
using Core.AssetManagement;
using Core.AssetManagement.Loading.LocalProviders;
using UI;
using UI.Views;

namespace Core.StateMachine
{
    public class GameOverState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IAssetProvider _assetProvider;

        private GameOverPanelProvider _gameOverPanelProvider;

        private UIGameOver UIGameOver => _gameOverPanelProvider.LoadedObject;

        public GameOverState(GameStateMachine stateMachine, IAssetProvider assetProvider)
        {
            _stateMachine = stateMachine;
            _assetProvider = assetProvider;
        }

        public async void Enter()
        {
            await LoadGameOverPanel();

            UIGameOver.MenuButton.onClick.AddListener(LoadMenu);
            UIGameOver.RestartButton.onClick.AddListener(RestartGame);
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
            
            UIGameOver.MenuButton.onClick.RemoveListener(LoadMenu);
            UIGameOver.RestartButton.onClick.RemoveListener(RestartGame);
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