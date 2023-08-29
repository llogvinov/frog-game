using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private readonly List<IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new List<IState>()
            {
                new BootstrapState(this)
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states.FirstOrDefault(s => s is TState);
            if (state == null)
            {
                Debug.LogError($"{typeof(TState)} is not added to states!");
                return;
            }
            _activeState = state;
            state.Enter();
        }
    }
}