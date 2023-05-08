﻿using UnityEngine;

namespace Core
{
    public class Utils
    {
        public const string MenuScene = "Menu";
        public const string GameScene = "Game";
        
        public const float SpriteWidth = 1f;
        public const float OffScreenOffset = 2f;
    
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