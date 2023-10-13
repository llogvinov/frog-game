using UI.Presenters;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class MenuScreenProvider : LocalAssetLoader<MenuPresenter>
    {
        protected override string AssetId => AddressablesLoadKeys.MenuScreen;
    }
}