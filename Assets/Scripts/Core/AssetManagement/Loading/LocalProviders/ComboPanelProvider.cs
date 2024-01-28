using UI;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class ComboPanelProvider : LocalAssetLoader<UICombo>
    {
        protected override string AssetId => AddressablesLoadKeys.ComboPanel;
    }
}