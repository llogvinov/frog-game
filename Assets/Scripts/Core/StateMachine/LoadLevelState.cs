namespace Core.StateMachine
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.Load(Utils.GameScene);
        }

        private void EnterLoadLevel()
        {
            
        }

        public void Exit()
        {
            
        }

        private void RegisterServices() { }
    }
}