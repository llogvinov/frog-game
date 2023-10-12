using Main.Enemy;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class FlySpawnerProvider : LocalAssetLoader<EnemySpawner>
    {
        protected override string AssetId => AddressablesLoadKeys.FlySpawner;
    }
    
    public class MosquitoSpawnerProvider : LocalAssetLoader<EnemySpawner>
    {
        protected override string AssetId => AddressablesLoadKeys.MosquitoSpawner;
    }
    
    public class DragonflySpawnerProvider : LocalAssetLoader<EnemySpawner>
    {
        protected override string AssetId => AddressablesLoadKeys.DragonflySpawner;
    }
    
    public class WaspSpawnerProvider : LocalAssetLoader<EnemySpawner>
    {
        protected override string AssetId => AddressablesLoadKeys.WaspSpawner;
    }
    
    public class SpiderSpawnerProvider : LocalAssetLoader<EnemySpawner>
    {
        protected override string AssetId => AddressablesLoadKeys.SpiderSpawner;
    }
}