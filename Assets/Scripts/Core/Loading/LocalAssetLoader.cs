using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.Loading
{
    public abstract class LocalAssetLoader<T>
    {
        private const byte LoadAttempts = 3;
        private const byte LoadTimeout = 3;
        
        private GameObject _loadedObject;

        protected abstract string AssetId { get; }

        public async Task<T> Load()
        {
            var handle = Addressables.InstantiateAsync(AssetId);

            int attempt = 1;
            do
            {
                await handle.Task;
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    _loadedObject = handle.Result;
                    if (_loadedObject.TryGetComponent(out T loadedObject) == false)
                    {
                        throw new NullReferenceException(
                            $"Object of type {typeof(T)} is null on attempt to load it from addressables with key {AssetId}");
                    }
                    
                    return loadedObject;
                }

                await Task.Delay(LoadTimeout * 1000);
            } while (++attempt < LoadAttempts);

            Debug.LogError($"Cannot load object of type {typeof(T)} from addressables with key {AssetId}");
            return default;
        }

        public void Unload()
        {
            if (_loadedObject == null) return;

            _loadedObject.SetActive(false);
            Addressables.ReleaseInstance(_loadedObject);
            _loadedObject = null;
        }
    }
}