using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.AssetManagement.Loading
{
    public abstract class LocalAssetLoader<T> where T : Component
    {
        private const byte LoadAttempts = 3;
        private const byte LoadTimeout = 3;
        
        private T _loadedObject;

        public T LoadedObject => _loadedObject;
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
                    var loadedObject = handle.Result;
                    if (loadedObject.TryGetComponent(out _loadedObject) == false)
                    {
                        throw new NullReferenceException(
                            $"Object of type {typeof(T)} is null on attempt to load it from addressables with key {AssetId}");
                    }
                    
                    return _loadedObject;
                }

                await Task.Delay(LoadTimeout * 1000);
            } while (++attempt < LoadAttempts);

            Debug.LogError($"Cannot load object of type {typeof(T)} from addressables with key {AssetId}");
            return default;
        }

        public void TryUnload()
        {
            if (_loadedObject != null) 
                Unload();
        }

        protected virtual void Unload()
        {
            var loadedObject = _loadedObject.gameObject;
            loadedObject.SetActive(false);
            Addressables.ReleaseInstance(loadedObject);
            _loadedObject = null;
        }
    }
}