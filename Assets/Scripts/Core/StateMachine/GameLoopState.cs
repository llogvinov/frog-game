using UI;

namespace Core.StateMachine
{
    public class GameLoopState : IPayloadState<UIManager>
    {
        private readonly GameStateMachine _stateMachine;
        
        private UIManager _uiManager;

        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter(UIManager uiManager)
        {
            _uiManager = uiManager;
            Game.GameOver += EnterGameOverState;
        }

        public void Exit()
        {
            Game.GameOver -= EnterGameOverState;
        }
        
        private void EnterGameOverState()
            => _stateMachine.Enter<GameOverState, UIManager>(_uiManager);
    }
}