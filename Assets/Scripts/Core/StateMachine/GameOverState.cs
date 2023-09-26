using Core.AssetManagement;
using Core.Factory;
using Presenters.GamePresenters;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameOverState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        public GameOverState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            GamePresenters.Instance.GameOverPresenter.MenuButton.onClick.AddListener(LoadMenu);
            GamePresenters.Instance.GameOverPresenter.RestartButton.onClick.AddListener(RestartGame);
            
            Object.Destroy(_gameFactory.Player.gameObject);
            Object.Destroy(_gameFactory.FrogGirl.gameObject);

            foreach (var spawner in _gameFactory.EnemySpawners)
            {
                spawner.ClearPool();
                Object.Destroy(spawner.gameObject);
            }
        }

        public void Exit()
        {
            GamePresenters.Instance.GameOverPresenter.MenuButton.onClick.RemoveListener(LoadMenu);
            GamePresenters.Instance.GameOverPresenter.RestartButton.onClick.RemoveListener(RestartGame);
        }

        private void LoadMenu() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.MenuScene);

        private void RestartGame() 
            => _stateMachine.Enter<LoadSceneState, string>(AssetPath.GameScene);
    }
}