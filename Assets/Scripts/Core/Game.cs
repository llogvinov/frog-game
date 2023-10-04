using System;
using Core.Loading.LocalProviders;
using Core.StateMachine;

namespace Core
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;

        public GameStateMachine StateMachine => _stateMachine;

        public static Action GameOver;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _stateMachine = new GameStateMachine(this, 
                new LoadingScreenProvider(), 
                new SceneLoader(coroutineRunner), 
                AllServices.Container);
        }

    }
}