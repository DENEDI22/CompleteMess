using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpawner : MonoBehaviour
{

    public SoundContainer[] sounds;


    protected void Awake()
    {
        if (sounds.Length > 0)
        {
            foreach (SoundContainer sound in sounds)
            {
                foreach (Sound s in sound.clips)
                {
                    s.source = gameObject.AddComponent<AudioSource>();
                    s.source.clip = s.clip;
                    s.source.volume = s.volume;
                    s.source.pitch = s.pitch;
                    s.source.loop = s.loop;
                    s.source.spatialBlend = s.soundByPosition ? 1 : 0;
                }
            }
        }
    }

    public void Play(string name)
    {
        SoundContainer sound = GetSoundContainer(name);

        foreach (Sound s in sound.clips)
        {
            if (s.source != null)
            {
                s.source.Play();
            }
            else
            {
                Debug.LogWarning("Sound " + ('"' + s.name + '"') + " does not have a source!");
            }
        }
    }

    public void Play(SoundContainer sound)
    {
        foreach (Sound s in sound.clips)
        {
            if (s.source != null)
            {
                s.source.Play();
            }
            else
            {
                Debug.LogWarning("Sound " + ('"' + s.name + '"') + " does not have a source!");
            }
        }
    }

    public void PlayAtPoint(string name, Vector3 position)
    {
        SoundContainer sound = GetSoundContainer(name);

        foreach (Sound s in sound.clips)
        {
            AudioSource.PlayClipAtPoint(s.source.clip, position);
        }
    }

    public SoundContainer GetSoundContainer(string name)
    {
        SoundContainer soundContainer = Array.Find(sounds, sound => sound.name == name);

        if (soundContainer.Equals(default(SoundContainer))) Debug.LogWarning("SoundContainer " + ('"' + name + '"') + " not found! Returning null");

        return soundContainer;
    }

    public Sound GetSound(SoundContainer sounds, string name)
    {
        Sound sound = Array.Find(sounds.clips, sound => sound.name == name);

        if (sound == null) Debug.LogWarning("Sound: " + name + " not found! Returning null");

        return sound;
    }

}
