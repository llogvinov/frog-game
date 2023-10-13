using System.Threading.Tasks;
using Core.AssetManagement;
using Core.AssetManagement.Loading.LocalProviders;
using UI.Views;

namespace Core.StateMachine
{
    public class MenuState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LoadingScreenProvider _loadingScreenProvider;

        private MenuScreenProvider _menuScreenProvider;
        private MenuView MenuView => _menuScreenProvider.LoadedObject.View;

        public MenuState(GameStateMachine stateMachine, LoadingScreenProvider loadingScreenProvider)
        {
            _stateMachine = stateMachine;
            _loadingScreenProvider = loadingScreenProvider;
        }

        public async void Enter()
        {
            await LoadMenuScreen();
            _loadingScreenProvider.TryUnload();
            MenuView.PlayButton.onClick.AddListener(LoadGame);
        }

        public void Exit()
        {
            _menuScreenProvider.TryUnload();
        }
        
        private async Task LoadMenuScreen()
        {
            _menuScreenProvider = new MenuScreenProvider();
            var loadTask = _menuScreenProvider.Load();
            await loadTask;
        }

        private void LoadGame()
        {
            MenuView.PlayButton.onClick.RemoveListener(LoadGame);
            _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
        }
    }
}