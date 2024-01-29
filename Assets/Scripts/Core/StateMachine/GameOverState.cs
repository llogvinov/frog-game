using Core.AssetManagement;
using UI;

namespace Core.StateMachine
{
    public class GameOverState : IPayloadState<UIManager>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IAssetProvider _assetProvider;

        private UIManager _uiManager;

        public GameOverState(GameStateMachine stateMachine, IAssetProvider assetProvider)
        {
            _stateMachine = stateMachine;
            _assetProvider = assetProvider;
        }

        public void Enter(UIManager uiManager)
        {
            _uiManager = uiManager;
            
            _uiManager.UIGameOver.Show();
            _uiManager.UIGameOver.MenuButton.onClick.AddListener(LoadMenu);
            _uiManager.UIGameOver.RestartButton.onClick.AddListener(RestartGame);
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
            
            _uiManager.UIGameOver.MenuButton.onClick.RemoveListener(LoadMenu);
            _uiManager.UIGameOver.RestartButton.onClick.RemoveListener(RestartGame);
            _uiManager.UIGameOver.Hide();
        }

        private void LoadMenu() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.MenuScene);

        private void RestartGame() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
    }
}