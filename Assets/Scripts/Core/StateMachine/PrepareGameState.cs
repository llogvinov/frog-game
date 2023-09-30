using System.Threading.Tasks;
using Core.Factory;
using Core.Loading.LocalProviders;
using Presenters.GamePresenters;

namespace Core.StateMachine
{
    public class PrepareGameState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        private HealthPanelProvider _healthPanelProvider;
        private HealthPresenter _healthPresenter;

        private ScorePanelProvider _scorePanelProvider;
        private ScorePresenter _scorePresenter;

        public PrepareGameState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public async void Enter()
        {
            await PrepareHealthPanel();
            await PrepareScorePanel();

            _gameFactory.InstantiatePlayer();
            _gameFactory.InstantiateFrogGirl();
            _gameFactory.InstantiateSpawners();

            Game.GameOver += ManipulatePresentersOnGameOver;
            
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private async Task PrepareHealthPanel()
        {
            await LoadHealthPanel();
            if (_healthPresenter != null)
                _healthPresenter.Init();
            
            async Task LoadHealthPanel()
            {
                _healthPanelProvider = new HealthPanelProvider();
                _healthPresenter = await _healthPanelProvider.Load();
            }
        }

        private async Task PrepareScorePanel()
        {
            await LoadScorePanel();
            if (_scorePresenter != null)
                _scorePresenter.Init();
            
            async Task LoadScorePanel()
            {
                _scorePanelProvider = new ScorePanelProvider();
                _scorePresenter = await _scorePanelProvider.Load();
            }
        }
        
        private void ManipulatePresentersOnGameOver()
        {
            _healthPanelProvider.Unload();
            _scorePanelProvider.Unload();
            GamePresenters.Instance.ComboPresenter.Switch(false);
        }
    }
}