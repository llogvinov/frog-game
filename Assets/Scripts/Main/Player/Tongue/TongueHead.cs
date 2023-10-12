using System;
using System.Collections.Generic;
using Core;
using Core.InputService;
using UnityEngine;

namespace Main.Player.Tongue
{
    public class TongueHead : BasePathMover
    {
        public Action HitStarted;

        private const float BaseScaler = 0.2f;
        
        [SerializeField] private TongueBase _tongueBase;
        
        private Vector3 _hitPosition;
        private InputService _playerInput;
        private SpriteVisualizer _headSprite;
        
        private void Start()
        {
            _playerInput = Application.isEditor ? 
                GetComponentInParent<ComputerInputService>() : 
                GetComponentInParent<MobileInputService>();
            _playerInput.HitSet += OnHitSet;
            MoveEnded += HideTongue;

            var spriteRenderer = GetComponent<SpriteRenderer>();
            _headSprite = new SpriteVisualizer(spriteRenderer);
            _headSprite.ToggleSpriteRenderer(false);
            Scale(BaseScaler);
        }
        
        private void OnDestroy()
        {
            _playerInput.HitSet -= OnHitSet;
            MoveEnded -= HideTongue;
        }

        public void Scale(float scaler) =>
            transform.localScale = Vector3.one * scaler;

        public void ResetScale() =>
            Scale(BaseScaler);

        private void OnHitSet(Vector3 hitPosition)
        {
            _hitPosition = hitPosition;
            _hitPosition.z = 0f;

            MovePositions = new Queue<Vector3>();
            MovePositions.Enqueue(_hitPosition);
            MovePositions.Enqueue(OriginalPosition);

            ShowTongue();
            MoveToNextPosition();
            HitStarted?.Invoke();
        }

        protected override void Move()
        {
            base.Move();
            
            _tongueBase.Stretch(OriginalPosition, transform.position);
        }

        private void ShowTongue()
        {
            _headSprite.ToggleSpriteRenderer(true);
            _tongueBase.BaseSprite.ToggleSpriteRenderer(true);
        }

        private void HideTongue()
        {
            _headSprite.ToggleSpriteRenderer(false);
            _tongueBase.BaseSprite.ToggleSpriteRenderer(false);
        }
    }
}