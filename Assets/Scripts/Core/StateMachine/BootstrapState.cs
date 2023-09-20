namespace Core.StateMachine
{
    public class BootstrapState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            RegisterServices();
            _stateMachine.Enter<MenuState>();
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            // TODO: implement
        }
    }
}