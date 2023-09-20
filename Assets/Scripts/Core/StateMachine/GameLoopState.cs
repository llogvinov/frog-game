using Presenters.GamePresenters;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameLoopState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;

        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            GamePresenters.Instance.GameOverPresenter.MenuButton.onClick.AddListener(LoadMenu);
            GamePresenters.Instance.GameOverPresenter.RestartButton.onClick.AddListener(RestartGame);
        }

        public void Exit()
        {
            GamePresenters.Instance.GameOverPresenter.MenuButton.onClick.RemoveListener(LoadMenu);
            GamePresenters.Instance.GameOverPresenter.RestartButton.onClick.RemoveListener(RestartGame);
            
            Object.Destroy(Game.Player.gameObject);
            Object.Destroy(Game.FrogGirl.gameObject);

            foreach (var spawner in Game.EnemySpawners)
            {
                spawner.ClearPool();
                Object.Destroy(spawner.gameObject);
            }
        }

        private void LoadMenu() 
            => _stateMachine.Enter<LoadSceneState, string>(Keys.MenuScene);

        private void RestartGame() 
            => _stateMachine.Enter<LoadSceneState, string>(Keys.GameScene);
    }
}