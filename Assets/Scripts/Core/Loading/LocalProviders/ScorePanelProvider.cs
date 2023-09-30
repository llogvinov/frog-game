using Presenters.GamePresenters;

namespace Core.Loading.LocalProviders
{
    public class ScorePanelProvider : LocalAssetLoader<ScorePresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.ScorePanel;
    }
}