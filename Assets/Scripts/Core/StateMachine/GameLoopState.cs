namespace Core.StateMachine
{
    public class GameLoopState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;

        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Game.GameOver += EnterGameOverState;
        }

        public void Exit()
        {
            Game.GameOver -= EnterGameOverState;
        }
        
        private void EnterGameOverState()
            => _stateMachine.Enter<GameOverState>();
    }
}