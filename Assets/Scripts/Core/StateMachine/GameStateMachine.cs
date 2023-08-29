using System.Collections.Generic;
using System.Linq;

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private readonly List<IState> _states;
        
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new List<IState>()
            {
                new BootstrapState(this),
                new MenuState(this),
                new LoadSceneState(this, sceneLoader),
                new PrepareGameState(this),
                new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, ISimpleState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
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