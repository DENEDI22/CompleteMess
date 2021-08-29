using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    PauseMenu pauseMenu;


    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    public void OnPauseGame(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) return;

        // Button Pressed
        if (context.started)
        {
            pauseMenu.OnPauseGame();
        }
    }

}
