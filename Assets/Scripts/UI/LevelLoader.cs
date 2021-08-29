using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    //public static LevelLoader instance;

    public Animator transition;

    public float transitionTime = 1f;

    /*
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    */

    public void LoadNextLevel()
    {
        StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousLevel()
    {
        StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(Load(levelIndex));
    }

    private IEnumerator Load(int levelIndex)
    {
        transition.SetBool("Start", true);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        transition.SetBool("Start", false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
