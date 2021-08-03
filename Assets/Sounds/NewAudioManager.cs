using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewAudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static NewAudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);  
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        Play("Theme");
        Play("bubbles");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }  
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Pause();
    }

    public void Volume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.volume = volume;
    }
}
