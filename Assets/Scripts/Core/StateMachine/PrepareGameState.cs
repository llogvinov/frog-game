using Core.Factory;
using UI;
using UnityEngine;

namespace Core.StateMachine
{
    public class PrepareGameState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly UILoading _uiLoading;
        
        private UIManager _uiManager;

        public PrepareGameState(GameStateMachine stateMachine, IGameFactory gameFactory,
            UILoading uiLoading)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _uiLoading = uiLoading;
        }

        public void Enter()
        {
            _uiManager = GameObject.FindObjectOfType<UIManager>();
            _uiManager.UIHealth.Init();
            _uiManager.UIScore.Init();
            _uiManager.UICombo.Init();
            
            _gameFactory.InstantiatePlayer();
            _gameFactory.InstantiateGirl();
            _gameFactory.InstantiateSpawners();

            Game.GameOver += OnGameOver;
            
            _stateMachine.Enter<GameLoopState, UIManager>(_uiManager);
        }

        public void Exit()
        {
            _uiLoading.Hide();
        }

        private void OnGameOver()
        {
            _uiManager.UIHealth.Hide();
            _uiManager.UIScore.Hide();
            _uiManager.UICombo.Hide();
        }
    }
}