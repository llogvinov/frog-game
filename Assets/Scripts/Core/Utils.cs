using UnityEngine;

namespace Core
{
    public class Utils
    {
        public const float SpriteWidth = 1f;
        public const float OffScreenOffset = 2f;

        /// <summary>
        /// Instantiate prefab from Resources folder
        /// </summary>
        /// <param name="path">Path to prefab</param>
        /// <returns></returns>
        public static GameObject Instantiate(string path)
        {
            var obj = Resources.Load<GameObject>(path);
            return Object.Instantiate(obj);
        }
        
        public static Vector3 RandomPositionOffTheScreen()
        {
            var width = GameManager.Instance.HalfWidth;
            var height = GameManager.Instance.HalfHeight;
        
            return new Vector3(
                Random.Range(
                    Random.Range(-width - SpriteWidth - OffScreenOffset, width), 
                    Random.Range(width, width + OffScreenOffset + SpriteWidth)),
                Random.Range(height, height + OffScreenOffset + SpriteWidth));
        }

        public static Vector3 RandomPositionOverTopOfScreen()
        {
            var width = GameManager.Instance.HalfWidth;
            var height = GameManager.Instance.HalfHeight;
        
            return new Vector3(
                Random.Range(-width, width),
                Random.Range(height, height + OffScreenOffset + SpriteWidth));
        }
        
        public static void SnapToPosition(Transform transformToSnap, Vector3 position) 
            => transformToSnap.position = position;
    
    }
}