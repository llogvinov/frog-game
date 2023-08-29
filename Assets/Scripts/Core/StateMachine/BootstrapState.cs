namespace Core.StateMachine
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            RegisterServices();
            _sceneLoader.LoadScene(Keys.MenuScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            // TODO: implement
        }

        private void EnterLoadLevel()
        {
            
        }
    }
}