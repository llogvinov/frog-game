namespace Core.StateMachine
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            RegisterServices();
        }

        public void Exit()
        {
            
        }

        private void RegisterServices() { }
    }
}