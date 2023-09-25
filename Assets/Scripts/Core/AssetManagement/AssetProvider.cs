using UnityEngine;

namespace Core.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            var obj = Resources.Load<GameObject>(path);
            return Object.Instantiate(obj);
        }
        
        public GameObject Instantiate(string path, Vector3 position)
        {
            var obj = Resources.Load<GameObject>(path);
            return Object.Instantiate(obj, position, Quaternion.identity);
        }
    }
}