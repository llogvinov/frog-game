using Core.Factory;
using Presenters.GamePresenters;

namespace Core.StateMachine
{
    public class PrepareGameState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        public PrepareGameState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            ManipulatePresentersOnEnter();
            
            _gameFactory.InstantiatePlayer();
            _gameFactory.InstantiateFrogGirl();
            _gameFactory.InstantiateSpawners();

            Game.GameOver += ManipulatePresentersOnGameOver;
            
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private void ManipulatePresentersOnEnter()
        {
            GamePresenters.Instance.GameOverPresenter.Switch(false);
            
            GamePresenters.Instance.ScorePresenter.Switch(true);
            GamePresenters.Instance.HealthPresenter.Switch(true);
            
            GamePresenters.Instance.ScorePresenter.Init();
            GamePresenters.Instance.HealthPresenter.Init();
        }

        private void ManipulatePresentersOnGameOver()
        {
            GamePresenters.Instance.ScorePresenter.Switch(false);
            GamePresenters.Instance.HealthPresenter.Switch(false);
            GamePresenters.Instance.ComboPresenter.Switch(false);
            
            GamePresenters.Instance.GameOverPresenter.Switch(true);
        }
    }
}