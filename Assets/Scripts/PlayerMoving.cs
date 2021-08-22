using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControls
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMoving : MonoBehaviour
    {

        public void OnMove(InputAction.CallbackContext _context)
        {
            Debug.Log($"Player OnMove invoked with axis: x: {_context.ReadValue<Vector2>().x} and y {_context.ReadValue<Vector2>().y}");
            transform.Translate(_context.ReadValue<Vector2>());
        }

        public void OnFire(InputAction.CallbackContext _context)
        {
            Debug.Log("FIRE!");
        }
    }
}