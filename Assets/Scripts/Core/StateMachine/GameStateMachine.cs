﻿using System.Collections.Generic;
using System.Linq;
using Core.AssetManagement;
using Core.AssetManagement.Loading.LocalProviders;
using Core.Factory;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private readonly List<IState> _states;
        private readonly Game _game;
        
        private IState _activeState;
        
        public GameStateMachine(Game game, LoadingScreenProvider loadingScreenProvider, SceneLoader sceneLoader, AllServices services)
        {
            _game = game;
            _states = new List<IState>
            {
                new BootstrapState(this, services),
                new MenuState(this, loadingScreenProvider),
                new LoadSceneState(this, sceneLoader, loadingScreenProvider),
                new PrepareGameState(this, services.Single<IGameFactory>(), loadingScreenProvider),
                new GameLoopState(this),
                new GameOverState(this, services.Single<IAssetProvider>()),
            };
        }

        public void Enter<TState>() where TState : class, ISimpleState
        {
            Debug.Log($"enter {typeof(TState)} state");
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            Debug.Log($"enter {typeof(TState)} state");
            var state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IState 
            => _states.FirstOrDefault(s => s is TState) as TState;
    }
}