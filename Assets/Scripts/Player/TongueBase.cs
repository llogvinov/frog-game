using System;
using UnityEngine;

namespace Player
{
    public class TongueBase : MonoBehaviour
    {
        private SpriteRenderer _baseVisual;
        private float _meshScale;

        public SpriteRenderer Visual => _baseVisual;

        private void Awake()
        {
            _baseVisual = GetComponent<SpriteRenderer>();
            _baseVisual.enabled = false;

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