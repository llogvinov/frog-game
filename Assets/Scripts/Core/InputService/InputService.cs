using System;
using System.Collections;
using UnityEngine;

namespace Core.InputService
{
    public abstract class InputService : MonoBehaviour, IService
    {
        #region Events

        public event Action<Vector3> HitSet;
        public event Action InputDone;

        protected void OnHitSet(Vector3 position) => 
            HitSet?.Invoke(position);

        protected void OnInputDone() => 
            InputDone?.Invoke();

        #endregion

        private bool _canHit;
        protected Camera Camera;

        private const float CoolDownDelay = 0.5f;
        
        private void Start()
        {
            Camera = Camera.main;
            _canHit = true;

            InputDone += StartCoolDownTimer;
        }

        private void OnDestroy()
        {
            InputDone -= StartCoolDownTimer;
        }
        
        private void Update()
        {
            if (_canHit) HandleInput();
        }

        protected virtual void HandleInput() { }

        private void StartCoolDownTimer() => StartCoroutine(CoolDownTimer());
        
        private IEnumerator CoolDownTimer()
        {
            _canHit = false;
            yield return new WaitForSeconds(CoolDownDelay);
            _canHit = true;
        }
    }
}