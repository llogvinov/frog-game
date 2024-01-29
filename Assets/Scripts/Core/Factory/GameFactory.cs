using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AssetManagement;
using Main.Enemy;
using Main.FrogGirl;
using Main.Player;
using UnityEngine;

namespace Core.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public Frog Frog { get; private set; }
        public Girl Girl { get; private set; }
        public List<EnemySpawner> EnemySpawners { get; private set; }

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Frog InstantiatePlayer()
        {
            var loaded = Resources.Load<Frog>(AssetPath.Frog);
            if (loaded == null) 
                Debug.LogError($"{typeof(Frog)} not found in resources");
            
            Frog = GameObject.Instantiate(loaded);
            return Frog;
        }

        public Girl InstantiateGirl()
        {
            var loaded = Resources.Load<Girl>(AssetPath.Girl);
            if (loaded == null) 
                Debug.LogError($"{typeof(Girl)} not found in resources");
            
            Girl = GameObject.Instantiate(loaded);
            return Girl;
        }
        
        public async Task InstantiateSpawners()
        {
            EnemySpawners = new List<EnemySpawner>
            {
                await _assetProvider.FlySpawnerProvider.Load(),
                await _assetProvider.MosquitoSpawnerProvider.Load(),
                await _assetProvider.DragonflySpawnerProvider.Load(),
                await _assetProvider.WaspSpawnerProvider.Load(),
                await _assetProvider.SpiderSpawnerProvider.Load(),
            };
            ActivateSpawners();

            void ActivateSpawners()
            {
                foreach (var spawner in EnemySpawners) 
                    spawner.Activate();
            }
        }
    }
}