using UI;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class HealthPanelProvider : LocalAssetLoader<UIHealth>
    {
        protected override string AssetId => AddressablesLoadKeys.HealthPanel;
    }
}