using UnityEngine;

namespace Core.InputService
{
    public class MobileInputService : InputService
    {
        protected override void HandleInput()
        {
            if (Input.touchCount <= 0) return;
            var touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Began) return;
            Vector3 hitPosition = touch.position;
            hitPosition.z = 0f;
            OnHitSet(Camera.ScreenToWorldPoint(hitPosition));
            OnInputDone();
        }
    }
}