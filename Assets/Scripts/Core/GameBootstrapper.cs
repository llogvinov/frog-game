using System;
using Core.StateMachine;
using UnityEngine;

namespace Core
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private static ScreenSettings _screen;
        private Game _game;
        
        public static float HalfHeight => _screen.HalfHeight;
        public static float HalfWidth => _screen.HalfWidth;

        private void Awake()
        {
            _screen = new ScreenSettings();
            
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}