using UI.Presenters.GamePresenters;

namespace Core.Loading.LocalProviders
{
    public class ComboPanelProvider : LocalAssetLoader<ComboPresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.ComboPanel;
    }
}