using Core.AssetManagement.Loading.LocalProviders;

namespace Core.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public FrogProvider FrogProvider { get; }
        public GirlProvider GirlProvider { get; }

        public FlySpawnerProvider FlySpawnerProvider { get; }
        public MosquitoSpawnerProvider MosquitoSpawnerProvider { get; }
        public DragonflySpawnerProvider DragonflySpawnerProvider { get; }
        public WaspSpawnerProvider WaspSpawnerProvider { get; }
        public SpiderSpawnerProvider SpiderSpawnerProvider { get; }

        public AssetProvider()
        {
            FrogProvider = new FrogProvider();
            GirlProvider = new GirlProvider();
            
            FlySpawnerProvider = new FlySpawnerProvider();
            MosquitoSpawnerProvider = new MosquitoSpawnerProvider();
            DragonflySpawnerProvider = new DragonflySpawnerProvider();
            WaspSpawnerProvider = new WaspSpawnerProvider();
            SpiderSpawnerProvider = new SpiderSpawnerProvider();
        }
    }
}