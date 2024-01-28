using Core.AssetManagement;
using Core.AssetManagement.Loading.LocalProviders;
using UI;
using UnityEngine;

namespace Core.StateMachine
{
    public class MenuState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LoadingScreenProvider _loadingScreenProvider;

        private UIMenu _uiMenu;

        public MenuState(GameStateMachine stateMachine, LoadingScreenProvider loadingScreenProvider)
        {
            _stateMachine = stateMachine;
            _loadingScreenProvider = loadingScreenProvider;
        }

        public void Enter()
        {
            _uiMenu = GameObject.FindObjectOfType<UIMenu>();
            _loadingScreenProvider.TryUnload();
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