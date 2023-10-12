using Main.FrogGirl;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class GirlProvider : LocalAssetLoader<Girl>
    {
        protected override string AssetId => AddressablesLoadKeys.Girl;
    }
}