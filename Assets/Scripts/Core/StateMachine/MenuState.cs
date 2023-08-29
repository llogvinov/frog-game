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
            
        }

        public void Exit()
        {
            
        }
    }
}