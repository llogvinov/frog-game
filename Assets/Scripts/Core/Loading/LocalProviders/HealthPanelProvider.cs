using Presenters.GamePresenters;

namespace Core.Loading.LocalProviders
{
    public class HealthPanelProvider : LocalAssetLoader<HealthPresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.HealthPanel;
    }
}