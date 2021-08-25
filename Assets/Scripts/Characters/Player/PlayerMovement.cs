using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{

    CharController player;

    Vector2 moveDir;
    Vector3 lookDir;
    float lookAngle;


    private void Awake()
    {
        player = gameObject.GetComponent<CharController>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(lookDir);
        player.Move(new Vector3(moveDir.x, 0, moveDir.y), player.speed);
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        moveDir = _context.ReadValue<Vector2>();
        lookAngle = 90f + Mathf.Atan2(moveDir.x, moveDir.y) * Mathf.Rad2Deg;
        lookDir = new Vector3(0, lookAngle, 0);
    }

}
