using System;
using System.Collections.Generic;
using Core;
using FrogGame;
using Player;
using UnityEngine;

namespace Tongue
{
    public class TongueHead : BasePathMover
    {
        public Action HitStarted;
        
        [SerializeField] private TongueBase _tongueBase;
        
        private Vector3 _hitPosition;
        private PlayerInput _playerInput;
        private SpriteVisualizer _headSprite;
        
        private void Start()
        {
            _playerInput = GetComponentInParent<PlayerInput>();
            _playerInput.HitSetEvent += OnHitSet;
            MoveEnded += HideTongue;

            var spriteRenderer = GetComponent<SpriteRenderer>();
            _headSprite = new SpriteVisualizer(spriteRenderer);
            _headSprite.ToggleSpriteRenderer(false);
        }
        
        private void OnDestroy()
        {
            _playerInput.HitSetEvent -= OnHitSet;
            MoveEnded -= HideTongue;
        }

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