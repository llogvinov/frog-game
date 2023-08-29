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
            InstantiatePlayer();
            InstantiateFrogGirl();
            InstantiateSpawners();
            
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private void InstantiatePlayer() 
            => Utils.Instantiate(Keys.PlayerPrefabPath);

        private void InstantiateFrogGirl()
        {
            Utils.Instantiate(Keys.FrogGirlPrefabPath);

            void SetTargets()
            {
                
            }
        }

        private void InstantiateSpawners()
        {
            Utils.Instantiate(Keys.FlySpawnerPrefabPath);
            Utils.Instantiate(Keys.MosquitoSpawnerPrefabPath);
            Utils.Instantiate(Keys.DragonflySpawnerPrefabPath);
            Utils.Instantiate(Keys.WaspSpawnerPrefabPath);
            Utils.Instantiate(Keys.SpiderSpawnerPrefabPath);
            
            void ActivateSpawners()
            {
            
            }
        }
    }
}