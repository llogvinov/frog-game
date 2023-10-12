using Core.AssetManagement.Loading.LocalProviders;

namespace Core.AssetManagement
{
    public interface IAssetProvider : IService
    {
        public FrogProvider FrogProvider { get; }
        public GirlProvider GirlProvider { get; }
        
        public FlySpawnerProvider FlySpawnerProvider { get; }
        public MosquitoSpawnerProvider MosquitoSpawnerProvider { get; }
        public DragonflySpawnerProvider DragonflySpawnerProvider { get; }
        public WaspSpawnerProvider WaspSpawnerProvider { get; }
        public SpiderSpawnerProvider SpiderSpawnerProvider { get; }
    }
}