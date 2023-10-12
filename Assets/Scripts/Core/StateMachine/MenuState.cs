using Core.AssetManagement;
using Core.AssetManagement.Loading.LocalProviders;
using Presenters.MenuPresenters;

namespace Core.StateMachine
{
    public class MenuState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LoadingScreenProvider _loadingScreenProvider;

        public MenuState(GameStateMachine stateMachine, LoadingScreenProvider loadingScreenProvider)
        {
            _stateMachine = stateMachine;
            _loadingScreenProvider = loadingScreenProvider;
        }

        public void Enter()
        {
            _loadingScreenProvider.TryUnload();
            MenuPresenters.Instance.PlayButton.onClick.AddListener(LoadGame);
        }

        public void Exit()
        {
            
        }

        private void LoadGame()
        {
            MenuPresenters.Instance.PlayButton.onClick.RemoveListener(LoadGame);
            _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
        }
    }
}