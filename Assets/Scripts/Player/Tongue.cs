using System;
using UnityEngine;

namespace Player
{
    public class Tongue : MonoBehaviour
    {
        [SerializeField] private TongueHead _tongueHead;
        [SerializeField] private TongueBase _tongueBase;
        [Space] 
        [SerializeField] private float _hitSpeed;

        private PlayerInput _playerInput;

        private bool _isHitSet;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }
        
        private void OnEnable()
        {
            _playerInput.HitSetEvent += OnHitSet;
            _tongueHead.HitEnded += OnHitEnded;
        }

        private void OnDisable()
        {
            _playerInput.HitSetEvent -= OnHitSet;
            _tongueHead.HitEnded -= OnHitEnded;
        }

        private void Update()
        {
            if (!_isHitSet) return;

            _tongueHead.Move(_hitSpeed, Time.deltaTime);
            _tongueBase.Stretch(_tongueHead.OriginalPosition, _tongueHead.transform.position);
        }

        private void OnHitSet(Vector3 hitPosition)
        {
            hitPosition.z = 0f;
            
            _tongueHead.SetPath(hitPosition);
            _tongueHead.Visual.enabled = true;
            _tongueBase.Visual.enabled = true;
            
            _isHitSet = true;
        }

        private void OnHitEnded()
        {
            _tongueHead.Visual.enabled = false;
            _tongueBase.Visual.enabled = false;
            
            _isHitSet = false;
        }
    }
}