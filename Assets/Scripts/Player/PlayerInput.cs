using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Events

    public delegate void HitSet(Vector3 hitPosition);

    public event HitSet HitSetEvent;

    #endregion

    [SerializeField] private float _coolDownDelay;

    private bool _canHit;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        HandleTouchInput();
        HandleMouseInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began) return;
        HitSetEvent?.Invoke(touch.position);
        _canHit = false;
        StartCoroutine(StartCoolDownTimer());
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            HitSetEvent?.Invoke(_camera.ScreenToWorldPoint(mousePosition));
        }
    }

    private IEnumerator StartCoolDownTimer()
    {
        yield return new WaitForSeconds(_coolDownDelay);
        _canHit = true;
    }
    
}
