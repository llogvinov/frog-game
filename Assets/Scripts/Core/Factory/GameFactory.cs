using System.Collections.Generic;
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
        
        public List<EnemySpawner> InstantiateSpawners()
        {
            EnemySpawners = new List<EnemySpawner>();

            InstantiateSpawner(AssetPath.FlySpawner);
            InstantiateSpawner(AssetPath.MosquitoSpawner);
            InstantiateSpawner(AssetPath.DragonflySpawner);
            InstantiateSpawner(AssetPath.WaspSpawner);
            InstantiateSpawner(AssetPath.SpiderSpawner);

            ActivateSpawners();

            return EnemySpawners;

            void InstantiateSpawner(string path)
            {
                var loaded = Resources.Load<EnemySpawner>(path);
                if (loaded == null)
                    Debug.LogError($"{typeof(EnemySpawner)} on path {path} not found in resources");
                var spawner = GameObject.Instantiate(loaded);
                EnemySpawners.Add(spawner);
            }

            void ActivateSpawners()
            {
                foreach (var spawner in EnemySpawners) 
                    spawner.Activate();
            }
        }
    }
}