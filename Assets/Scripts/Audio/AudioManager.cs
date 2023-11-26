using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (SceneManager.GetActiveScene().name == "Sound Test")
        {
            Play("Level Music");
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Play("Menu Music");
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.soundName == sound);
        s.source.Play();
    }
    
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.soundName == sound);
        s.source.Stop();
    }
}
