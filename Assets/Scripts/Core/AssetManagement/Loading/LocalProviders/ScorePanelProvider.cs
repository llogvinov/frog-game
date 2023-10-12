using UI.Presenters.GamePresenters;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class ScorePanelProvider : LocalAssetLoader<ScorePresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.ScorePanel;
    }
}