using UnityEngine;

namespace Core.InputService
{
    public class ComputerInputService : InputService
    {
        protected override void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                OnHitSet(Camera.ScreenToWorldPoint(mousePosition));
                OnInputDone();
            }
        }
    }
}