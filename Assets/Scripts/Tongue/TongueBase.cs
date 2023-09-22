using UnityEngine;

namespace Tongue
{
    public class TongueBase : MonoBehaviour
    {
        public SpriteVisualizer BaseSprite { get; private set; }
        private float _meshScale;

        private void Awake()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            BaseSprite = new SpriteVisualizer(spriteRenderer);
            BaseSprite.ToggleSpriteRenderer(false);

            _meshScale = transform.parent.lossyScale.y;
        }

        public void Stretch(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 centerPosition = (endPosition + startPosition) / 2f;
            transform.position = centerPosition;

            Vector3 direction = (endPosition - startPosition).normalized;
            transform.up = direction;

            Vector3 scale = new Vector3(0.15f, 1f, 1f);
            scale.y = Vector3.Distance(startPosition, endPosition);
            scale.y /= _meshScale;
            transform.localScale = scale;
        }
    }
}