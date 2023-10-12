using System;
using System.Threading.Tasks;

namespace Core.AssetManagement.Loading
{
    public interface ILoadingOperation
    {
        string Description { get; }
        Task Load(Action<float> onProgress);
    }
}