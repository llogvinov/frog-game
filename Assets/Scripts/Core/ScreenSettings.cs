using UnityEngine;

namespace Core
{
    class ScreenSettings
    {
        private readonly Camera _camera;

        public readonly float HalfHeight;
        public readonly float HalfWidth;
        
        public ScreenSettings()
        {
            _camera = Camera.main;
            HalfHeight = _camera.orthographicSize;
            HalfWidth = _camera.aspect * HalfHeight;
        }
    }
}