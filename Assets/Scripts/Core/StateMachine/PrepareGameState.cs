using System.Threading.Tasks;
using Core.Factory;
using Core.Loading.LocalProviders;
using UI.Presenters.GamePresenters;

namespace Core.StateMachine
{
    public class PrepareGameState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly LoadingScreenProvider _loadingScreenProvider;

        private HealthPanelProvider _healthPanelProvider;
        private ScorePanelProvider _scorePanelProvider;

        public PrepareGameState(GameStateMachine stateMachine, IGameFactory gameFactory,
            LoadingScreenProvider loadingScreenProvider)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _loadingScreenProvider = loadingScreenProvider;
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
            _loadingScreenProvider.TryUnload();
        }

        private async Task PrepareHealthPanel()
        {
            await LoadHealthPanel();
            _healthPanelProvider?.LoadedObject.Init();
            
            async Task LoadHealthPanel()
            {
                _healthPanelProvider = new HealthPanelProvider();
                var loadTask = _healthPanelProvider.Load();
                await loadTask;
            }
        }

        private async Task PrepareScorePanel()
        {
            await LoadScorePanel();
            _scorePanelProvider?.LoadedObject.Init();
            
            async Task LoadScorePanel()
            {
                _scorePanelProvider = new ScorePanelProvider();
                var loadTask = _scorePanelProvider.Load();
                await loadTask;
            }
        }

        private void ManipulatePresentersOnGameOver()
        {
            _healthPanelProvider.TryUnload();
            _scorePanelProvider.TryUnload();
            GamePresenters.Instance.ComboPresenter.Switch(false);
        }
    }
}