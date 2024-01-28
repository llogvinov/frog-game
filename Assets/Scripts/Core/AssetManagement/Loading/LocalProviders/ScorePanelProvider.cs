using UI;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class ScorePanelProvider : LocalAssetLoader<UIScore>
    {
        protected override string AssetId => AddressablesLoadKeys.ScorePanel;
    }
}