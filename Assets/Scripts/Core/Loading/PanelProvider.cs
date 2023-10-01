using System.Threading.Tasks;
using UI.Presenters;

namespace Core.Loading
{
    public class PanelProvider<TProvider, TPresenter> 
        where TProvider : LocalAssetLoader<TPresenter>
        where TPresenter : BasePresenter
    {
        private readonly TProvider _assetLoader;
        public TPresenter Presenter;

        public PanelProvider(TProvider assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public async Task Load() => 
            Presenter = await _assetLoader.Load();

        public void Unload() => 
            _assetLoader.Unload();
    }
}