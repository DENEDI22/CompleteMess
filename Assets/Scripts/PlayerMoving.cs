using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace PlayerControls
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMoving : MonoBehaviour
    {
        private void Awake()
        {
            FindObjectOfType<Cinemachine.CinemachineTargetGroup>().AddMember(transform, 1, 1);
        }

        public void OnMove(InputAction.CallbackContext _context)
        {
            transform.Translate(_context.ReadValue<Vector2>().x, 0, _context.ReadValue<Vector2>().y);
        }

        public void OnFire(InputAction.CallbackContext _context)
        {
            Debug.Log("FIRE!");
        }
    }
}