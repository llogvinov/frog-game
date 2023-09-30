using Views;

namespace Core.Loading.LocalProviders
{
    public class LoadingScreenProvider : LocalAssetLoader<LoadingScreenView>
    {
        protected override string AssetId => AddressablesLoadKeys.LoadingScreen;
    }
}