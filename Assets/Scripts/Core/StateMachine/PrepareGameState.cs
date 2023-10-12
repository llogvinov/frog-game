using System.Threading.Tasks;
using Core.AssetManagement.Loading.LocalProviders;
using Core.Factory;

namespace Core.StateMachine
{
    public class PrepareGameState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly LoadingScreenProvider _loadingScreenProvider;

        private HealthPanelProvider _healthPanelProvider;
        private ScorePanelProvider _scorePanelProvider;
        private ComboPanelProvider _comboPanelProvider;

        public PrepareGameState(GameStateMachine stateMachine, IGameFactory gameFactory,
            LoadingScreenProvider loadingScreenProvider)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _loadingScreenProvider = loadingScreenProvider;
        }

        public async void Enter()
        {
            await _gameFactory.InstantiatePlayer();
            await _gameFactory.InstantiateFrogGirl();
            await _gameFactory.InstantiateSpawners();
            
            await PrepareHealthPanel();
            await PrepareScorePanel();
            await PrepareComboPanel();

            Game.GameOver += OnGameOver;
            
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

        private async Task PrepareComboPanel()
        {
            await LoadComboPanel();
            _comboPanelProvider?.LoadedObject.Init();
            
            async Task LoadComboPanel()
            {
                _comboPanelProvider = new ComboPanelProvider();
                var loadTask = _comboPanelProvider.Load();
                await loadTask;
            }
        }

        private void OnGameOver()
        {
            _healthPanelProvider.TryUnload();
            _scorePanelProvider.TryUnload();
            _comboPanelProvider.TryUnload();
        }
    }
}