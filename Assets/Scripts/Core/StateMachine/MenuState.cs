using Core.AssetManagement;
using Presenters.MenuPresenters;

namespace Core.StateMachine
{
    public class MenuState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;

        public MenuState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
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