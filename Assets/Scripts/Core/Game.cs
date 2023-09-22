using System;
using System.Collections.Generic;
using Core.StateMachine;
using Enemy;

namespace Core
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;

        public GameStateMachine StateMachine => _stateMachine;
        public static Player.Player Player { get; set; }
        public static FrogGirl.FrogGirl FrogGirl { get; set; }
        public static List<EnemySpawner> EnemySpawners { get; set; }
        
        public static Action GameOver;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _stateMachine = new GameStateMachine(this, new SceneLoader(coroutineRunner));
        }

    }
}