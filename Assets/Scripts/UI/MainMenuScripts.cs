using System.Collections;
using System.Collections.Generic;
using SoundSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
