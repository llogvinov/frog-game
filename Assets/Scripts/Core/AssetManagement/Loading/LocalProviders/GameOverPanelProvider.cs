using UI;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class GameOverPanelProvider : LocalAssetLoader<UIGameOver>
    {
        protected override string AssetId => AddressablesLoadKeys.GameOverPanel;
    }
}