using Main.Player;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class FrogProvider : LocalAssetLoader<Frog>
    {
        protected override string AssetId => AddressablesLoadKeys.Frog;
    }
}