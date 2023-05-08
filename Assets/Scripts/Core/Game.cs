using Core.StateMachine;

namespace Core
{
    public class Game
    {
        public GameStateMachine StateMachine;
        
        public Game()
        {
            StateMachine = new GameStateMachine();
        }
    }
}