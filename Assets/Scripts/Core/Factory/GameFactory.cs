using System.Collections.Generic;
using Core.AssetManagement;
using Enemy;

namespace Core.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public Player.Player InstantiatePlayer() 
            => _assetProvider.Instantiate(AssetPath.PlayerPrefabPath).GetComponent<Player.Player>();

        public FrogGirl.FrogGirl InstantiateFrogGirl() 
            => _assetProvider.Instantiate(AssetPath.FrogGirlPrefabPath).GetComponent<FrogGirl.FrogGirl>();

        public List<EnemySpawner> InstantiateSpawners()
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
            
            return enemySpawners;
            
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