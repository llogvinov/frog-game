using System;
using System.Collections.Generic;

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(MenuState)] = new MenuState(this, sceneLoader),
                [typeof(LoadSceneState)] = new LoadSceneState(this, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(this, sceneLoader),
                [typeof(GameOverState)] = new GameOverState(this, sceneLoader),
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}
