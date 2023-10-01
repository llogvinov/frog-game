using UI.Presenters.GamePresenters;

namespace Core.Loading.LocalProviders
{
    public class GameOverPanelProvider : LocalAssetLoader<GameOverPresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.GameOverPanel;
    }
}