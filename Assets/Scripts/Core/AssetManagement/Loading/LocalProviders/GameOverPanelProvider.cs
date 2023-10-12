using UI.Presenters.GamePresenters;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class GameOverPanelProvider : LocalAssetLoader<GameOverPresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.GameOverPanel;
    }
}