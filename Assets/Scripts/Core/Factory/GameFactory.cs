using System.Collections.Generic;
using Core.AssetManagement;
using Main.Enemy;
using Main.FrogGirl;
using Main.Player;

namespace Core.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public Frog Frog { get; private set; }
        public Girl Girl { get; private set; }
        public List<EnemySpawner> EnemySpawners { get; private set; } = new();

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void InstantiatePlayer() 
            => Frog = _assetProvider.Instantiate(AssetPath.PlayerPrefabPath).GetComponent<Frog>();

        public void InstantiateFrogGirl() 
            => Girl = _assetProvider.Instantiate(AssetPath.FrogGirlPrefabPath).GetComponent<Girl>();

        public void InstantiateSpawners()
        {
            List<EnemySpawner> enemySpawners = new ()
            {
                InstantiateSpawner(AssetPath.FlySpawnerPrefabPath),
                InstantiateSpawner(AssetPath.MosquitoSpawnerPrefabPath),
                InstantiateSpawner(AssetPath.DragonflySpawnerPrefabPath),
                InstantiateSpawner(AssetPath.WaspSpawnerPrefabPath),
                InstantiateSpawner(AssetPath.SpiderSpawnerPrefabPath),
                InstantiateSpawner(AssetPath.ButterflySpawnerPrefabPath),
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