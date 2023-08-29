using Core.StateMachine;

namespace Core
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;
        
        public GameStateMachine StateMachine => _stateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }

    }
}