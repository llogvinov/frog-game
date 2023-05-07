using System.Collections;
using Core;
using UnityEngine;

namespace Player
{
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
            _canHit = true;
        }

        private void Start()
        {
            GameManager.Instance.GameOver += OnGameOver ;
        }

        private void OnDestroy()
        {
            GameManager.Instance.GameOver -= OnGameOver;
        }

        private void Update()
        {
            if (_canHit)
            {
                HandleTouchInput();
                //HandleMouseInput();
            }
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount <= 0) return;
            var touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Began) return;
            Vector3 hitPosition = touch.position;
            hitPosition.z = 0f;
            HitSetEvent?.Invoke(_camera.ScreenToWorldPoint(hitPosition));
            StartCoroutine(StartCoolDownTimer());
        }

        private void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                HitSetEvent?.Invoke(_camera.ScreenToWorldPoint(mousePosition));
                StartCoroutine(StartCoolDownTimer());
            }
        }

        private IEnumerator StartCoolDownTimer()
        {
            _canHit = false;
            yield return new WaitForSeconds(_coolDownDelay);
            _canHit = true;
        }

        private void OnGameOver() => enabled = false;

    }
}
