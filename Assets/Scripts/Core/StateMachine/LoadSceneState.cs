using Core.AssetManagement;
using UI;

namespace Core.StateMachine
{
    public class LoadSceneState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UILoading _uiLoading;

        private string _loadingScene;

        public LoadSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader,
            UILoading uiLoading)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiLoading = uiLoading;
        }
        
        public void Enter(string sceneName)
        {
            _loadingScene = sceneName;
            _uiLoading.Show();
            _sceneLoader.LoadScene(sceneName, OnSceneLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnSceneLoaded()
        {
            switch (_loadingScene)
            {
                case AssetPath.GameScene:
                    _stateMachine.Enter<PrepareGameState>();
                    break;
                case AssetPath.MenuScene:
                    _stateMachine.Enter<MenuState>();
                    break;
            }
        }
    }
}