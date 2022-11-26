using UnityEngine;

namespace FrogGame
{
    public class SpriteVisualizer
    {
        private readonly SpriteRenderer _spriteRenderer;
        
        public SpriteVisualizer(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        public void ToggleSpriteRenderer(bool enable)
        {
            if (_spriteRenderer == null) return;
            _spriteRenderer.enabled = enable;
        }
    }
}