using System.Threading.Tasks;
using UI;

namespace Core.AssetManagement.Loading.LocalProviders
{
    public class LoadingScreenProvider : LocalAssetLoader<UILoading>
    {
        /// <summary>
        /// Delay before unloading UI screen (in milliseconds)
        /// </summary>
        private const int UnloadDelay = 100;

        protected override string AssetId => AddressablesLoadKeys.LoadingScreen;

        protected override async void Unload()
        {
            await Task.Delay(UnloadDelay);
            base.Unload();
        }
    }
}