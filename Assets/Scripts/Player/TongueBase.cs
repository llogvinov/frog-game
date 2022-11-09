using System;
using UnityEngine;

namespace Player
{
    public class TongueBase : MonoBehaviour
    {
        [Tooltip("Set Sprite Renderer if not on the same Game Object")]
        [SerializeField] private SpriteRenderer _baseVisual;

        private Transform _tongueBase;

        public SpriteRenderer BaseVisual => _baseVisual;

        private void Awake()
        {
            if (_baseVisual == null) _baseVisual = GetComponent<SpriteRenderer>();
            _tongueBase = _baseVisual.transform;
        }

        public void ScaleTongue(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 centerPosition = (endPosition + startPosition) / 2f;
            _tongueBase.position = centerPosition;

            Vector3 direction = (endPosition - startPosition).normalized;
            _tongueBase.up = direction;

            Vector3 scale = new Vector3(0.15f, 1f, 1f);
            scale.y = Vector3.Distance(startPosition, endPosition);
            scale.y *= 0.6f;
            _tongueBase.localScale = scale;
        }
    }
}