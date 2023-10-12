using UI.Presenters.GamePresenters;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class HealthPanelProvider : LocalAssetLoader<HealthPresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.HealthPanel;
    }
}