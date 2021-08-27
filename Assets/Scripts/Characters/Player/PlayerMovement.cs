using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float rotationSmoothSpeed = 1f;

    CharController player;
    [SerializeField] PlayerInput playerInput;

    Vector2 moveDir;
    Vector3 lookDir;
    float lookAngle;


    private void Awake()
    {
        player = gameObject.GetComponent<CharController>();
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(lookDir), rotationSmoothSpeed * Time.fixedDeltaTime);
        player.Move(new Vector3(moveDir.x, 0, moveDir.y), player.speed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (playerInput.currentControlScheme == null) return;

        // Control Scheme for controller: "Gamepad"

        if (playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Vector3 dir = (new Vector3(mousePos.x, mousePos.y, 0) - position).normalized;
            lookAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        }
        else
        {
            Vector2 dir = context.ReadValue<Vector2>();
            lookAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        }

        lookDir = new Vector3(0, lookAngle, 0);
    }

}
