using System;
using System.Threading.Tasks;

namespace Core.Loading
{
    public interface ILoadingOperation
    {
        string Description { get; }
        Task Load(Action<float> onProgress);
    }
}