using System;
using SoundSystem;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    
    public void SaveSFXVolume(float _newVolume)
    {
        PlayerPrefs.SetFloat("SFXVolume", _newVolume);
        PlayerPrefs.Save();
    }

    public void SaveMusicVolume(float _newVolume)
    {
        PlayerPrefs.SetFloat("MusicVolume", _newVolume);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 0f);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 0f);
            PlayerPrefs.Save();
        }
        
        LoadSoundSettings();
    }

    private void LoadSoundSettings()
    {
        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", 0f));
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 0f));
    }
}