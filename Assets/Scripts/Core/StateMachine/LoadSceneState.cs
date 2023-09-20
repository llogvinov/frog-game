namespace Core.StateMachine
{
    public class LoadSceneState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        private string _loadingScene;

        public LoadSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string sceneName)
        {
            _loadingScene = sceneName;
            _sceneLoader.LoadScene(sceneName, OnSceneLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnSceneLoaded()
        {
            switch (_loadingScene)
            {
                case Keys.GameScene:
                    _stateMachine.Enter<PrepareGameState>();
                    break;
                case Keys.MenuScene:
                    _stateMachine.Enter<MenuState>();
                    break;
            }
        }
    }
}