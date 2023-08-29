namespace Core.StateMachine
{
    public class LoadSceneState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName, OnSceneLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnSceneLoaded()
        {
            _stateMachine.Enter<PrepareGameState>();
        }
    }
}