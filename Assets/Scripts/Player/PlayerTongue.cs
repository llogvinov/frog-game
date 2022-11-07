using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerTongue : MonoBehaviour
{
    public Action HitEnded;

    [SerializeField] private Transform _tongueBase;
    [SerializeField] private Transform _tongueHead;
    [SerializeField] private float _hitSpeed;

    private PlayerInput _playerInput;
    private Vector3 _initialHeadPosition;
    private Vector3 _hitPosition;
    private bool _isHitting;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _initialHeadPosition = _tongueHead.position;
        _tongueBase.gameObject.SetActive(false);
        _tongueHead.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _playerInput.HitSetEvent += OnHitSet;
    }

    private void OnDisable()
    {
        _playerInput.HitSetEvent -= OnHitSet;
    }

    private void Update()
    {
        if (!_isHitting) return;

        _tongueHead.position = Vector3.MoveTowards(_tongueHead.position, _hitPosition, _hitSpeed * Time.deltaTime);
        
        // move base center
        var centerPos = (_tongueHead.position + _initialHeadPosition) / 2f;
        _tongueBase.position = centerPos;
        
        // scale base
        var scale = Vector3.Distance(_initialHeadPosition, _tongueHead.position);
        _tongueBase.localScale = new Vector3(_tongueBase.localScale.x, scale * 0.6f, 1);
        
        if ((_hitPosition - _tongueHead.position).sqrMagnitude < 0.001f)
        {
            _isHitting = false;
            SnapToPosition(_hitPosition);
        }
    }

    private void OnHitSet(Vector3 hitPosition)
    {
        _hitPosition = hitPosition;
        _hitPosition.z = 0f;
        _tongueBase.up = _hitPosition - _initialHeadPosition;
        _tongueBase.gameObject.SetActive(true);
        _tongueHead.gameObject.SetActive(true);
        
        _isHitting = true;
    }
    
    private void SnapToPosition(Vector3 position)
    {
        _tongueHead.position = position;
    }

}
