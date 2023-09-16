using System.Collections.Generic;
using FrogGame.Enemy;
using Presenters.GamePresenters;

namespace Core.StateMachine
{
    public class PrepareGameState : ISimpleState
    {
        private readonly GameStateMachine _stateMachine;

        public PrepareGameState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            ManipulatePresentersOnEnter();
            
            Game.Player = InstantiatePlayer();
            Game.FrogGirl = InstantiateFrogGirl();
            Game.EnemySpawners = InstantiateSpawners();

            Game.GameOver += ManipulatePresenters;
            
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private Player.Player InstantiatePlayer() 
            => Utils.Instantiate(Keys.PlayerPrefabPath).GetComponent<Player.Player>();

        private FrogGirl.FrogGirl InstantiateFrogGirl() 
            => Utils.Instantiate(Keys.FrogGirlPrefabPath).GetComponent<FrogGirl.FrogGirl>();

        private List<EnemySpawner> InstantiateSpawners()
        {
            List<EnemySpawner> enemySpawners = new ()
            {
                InstantiateSpawner(Keys.FlySpawnerPrefabPath),
                InstantiateSpawner(Keys.MosquitoSpawnerPrefabPath),
                InstantiateSpawner(Keys.DragonflySpawnerPrefabPath),
                InstantiateSpawner(Keys.WaspSpawnerPrefabPath),
                InstantiateSpawner(Keys.SpiderSpawnerPrefabPath),
            };
            
            ActivateSpawners();
            
            return enemySpawners;
            
            EnemySpawner InstantiateSpawner(string path) 
                => Utils.Instantiate(path).GetComponent<EnemySpawner>();

            void ActivateSpawners()
            {
                foreach (var spawner in enemySpawners) 
                    spawner.Activate();
            }
        }

        private void ManipulatePresentersOnEnter()
        {
            GamePresenters.Instance.GameOverPresenter.Switch(false);
            
            GamePresenters.Instance.ScorePresenter.Switch(true);
            GamePresenters.Instance.HealthPresenter.Switch(true);
            
            GamePresenters.Instance.ScorePresenter.Init();
            GamePresenters.Instance.HealthPresenter.Init();
        }

        private void ManipulatePresenters()
        {
            GamePresenters.Instance.ScorePresenter.Switch(false);
            GamePresenters.Instance.HealthPresenter.Switch(false);
            GamePresenters.Instance.ComboPresenter.Switch(false);
            
            GamePresenters.Instance.GameOverPresenter.Switch(true);
        }
    }
}