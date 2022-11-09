using System;
using UnityEngine;

namespace Player
{
    public class TongueBase : MonoBehaviour
    {
        private SpriteRenderer _baseVisual;

        public SpriteRenderer Visual => _baseVisual;

        private void Awake()
        {
            _baseVisual = GetComponent<SpriteRenderer>();
            _baseVisual.enabled = false;
        }

        public void Stretch(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 centerPosition = (endPosition + startPosition) / 2f;
            transform.position = centerPosition;

            Vector3 direction = (endPosition - startPosition).normalized;
            transform.up = direction;

            Vector3 scale = new Vector3(0.15f, 1f, 1f);
            scale.y = Vector3.Distance(startPosition, endPosition);
            scale.y *= 0.6f;
            transform.localScale = scale;
        }
    }
}