using System;
using System.Collections;
using System.Collections.Generic;
using SoundSystem;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerTracker : MonoBehaviour
{
    private int playersCounter;
    private LevelLoader m_levelLoader;

    [SerializeField] private TextMeshProUGUI countDownText;

    [SerializeField] private GameObject GameOverScreen;

    private void Awake()
    {
        m_levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void OnPlayerJoined(PlayerInput _player)
    {
        var tmp = _player.GetComponent<Character>();
        playersCounter++;
        tmp.deathEvent += OnPlayerDiesEvent;
    }

    private void OnPlayerDiesEvent()
    {
        if (playersCounter > 1)
        {
            playersCounter--;
            if (playersCounter == 1)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        GameOverScreen.SetActive(true);
        StartCoroutine(CountDown(5));
    }

    private IEnumerator CountDown(int _time)
    {
        while (_time > 0)
        {
            yield return new WaitForSeconds(1);
            _time--;
            countDownText.text = _time.ToString();
        }

        m_levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}