using System.Collections.Generic;
using System.Threading.Tasks;
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
        public List<EnemySpawner> EnemySpawners { get; private set; }

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public async Task InstantiatePlayer()
        {
            var task = _assetProvider.FrogProvider.Load();
            Frog = await task;
        }

        public async Task InstantiateFrogGirl()
        {
            var task = _assetProvider.GirlProvider.Load();
            Girl = await task;
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