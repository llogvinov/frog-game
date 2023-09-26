using System.Collections.Generic;
using Core.AssetManagement;
using Enemy;

namespace Core.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public Player.Player Player { get; private set; }
        public FrogGirl.FrogGirl FrogGirl { get; private set; }
        public List<EnemySpawner> EnemySpawners { get; private set; } = new();

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void InstantiatePlayer() 
            => Player = _assetProvider.Instantiate(AssetPath.PlayerPrefabPath).GetComponent<Player.Player>();

        public void InstantiateFrogGirl() 
            => FrogGirl = _assetProvider.Instantiate(AssetPath.FrogGirlPrefabPath).GetComponent<FrogGirl.FrogGirl>();

        public void InstantiateSpawners()
        {
            List<EnemySpawner> enemySpawners = new ()
            {
                InstantiateSpawner(AssetPath.FlySpawnerPrefabPath),
                InstantiateSpawner(AssetPath.MosquitoSpawnerPrefabPath),
                InstantiateSpawner(AssetPath.DragonflySpawnerPrefabPath),
                InstantiateSpawner(AssetPath.WaspSpawnerPrefabPath),
                InstantiateSpawner(AssetPath.SpiderSpawnerPrefabPath),
            };
            
            ActivateSpawners();
            
            EnemySpawners = enemySpawners;
            
            EnemySpawner InstantiateSpawner(string path) 
                => _assetProvider.Instantiate(path).GetComponent<EnemySpawner>();

            void ActivateSpawners()
            {
                foreach (var spawner in enemySpawners) 
                    spawner.Activate();
            }
        }
    }
}