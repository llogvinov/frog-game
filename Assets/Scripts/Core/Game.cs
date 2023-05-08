using Core.StateMachine;

namespace Core
{
    public class Game
    {
        public GameStateMachine StateMachine;
        
        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}