using Core.AssetManagement;
using UI;
using UnityEngine;

namespace Core.StateMachine
{
    public class MenuState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UILoading _uiLoading;

        private UIMenu _uiMenu;

        public MenuState(GameStateMachine stateMachine, UILoading uiLoading)
        {
            _stateMachine = stateMachine;
            _uiLoading = uiLoading;
        }

        public void Enter()
        {
            _uiMenu = GameObject.FindObjectOfType<UIMenu>();
            _uiLoading.Hide();
            _uiMenu.PlayButton.onClick.AddListener(LoadGame);
        }

        public void Exit()
        {
            _uiMenu.PlayButton.onClick.RemoveListener(LoadGame);
        }

        private void LoadGame()
        {
            _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
        }
    }
}