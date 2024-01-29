using System;
using Core.AssetManagement.Loading.LocalProviders;
using Core.StateMachine;
using UI;

namespace Core
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;

        public GameStateMachine StateMachine => _stateMachine;

        public static Action GameOver;

        public Game(ICoroutineRunner coroutineRunner, UILoading uiLoading)
        {
            _stateMachine = new GameStateMachine(this, 
                uiLoading, 
                new SceneLoader(coroutineRunner), 
                AllServices.Container);
        }

    }
}