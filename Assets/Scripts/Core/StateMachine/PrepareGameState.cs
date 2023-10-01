using System.Threading.Tasks;
using Core.Factory;
using Core.Loading;
using Core.Loading.LocalProviders;
using UI.Presenters.GamePresenters;

namespace Core.StateMachine
{
    public class PrepareGameState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        private PanelProvider<HealthPanelProvider, HealthPresenter> _healthPanelProvider;
        private PanelProvider<ScorePanelProvider, ScorePresenter> _scorePanelProvider;

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
            if (_healthPanelProvider.Presenter != null)
                _healthPanelProvider.Presenter.Init();
            
            async Task LoadHealthPanel()
            {
                _healthPanelProvider = new PanelProvider<HealthPanelProvider, HealthPresenter>
                    (new HealthPanelProvider());
                var loadTask = _healthPanelProvider.Load();
                await loadTask;
            }
        }

        private async Task PrepareScorePanel()
        {
            await LoadScorePanel();
            if (_scorePanelProvider.Presenter != null)
                _scorePanelProvider.Presenter.Init();
            
            async Task LoadScorePanel()
            {
                _scorePanelProvider = new PanelProvider<ScorePanelProvider, ScorePresenter>
                    (new ScorePanelProvider());
                var loadTask = _scorePanelProvider.Load();
                await loadTask;
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