using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SoundSpawner
{

    public static AudioManager instance;

    GameObject player;


    private new void Awake()
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

        base.Awake();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.GetComponent<Character>().deathEvent += OnPlayerDeath;
        }
    }

    public void OnPlayerDeath()
    {
        player.GetComponent<Character>().deathEvent -= OnPlayerDeath;
    }

}
