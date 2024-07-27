using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClipProperties[] clipProperties;
    
    public static Action<string> PlayAudio;
    
   
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        foreach (AudioClipProperties clip in clipProperties)
        {
            clip.source = gameObject.AddComponent<AudioSource>();
            clip.source.clip = clip.clip;
            clip.source.volume = clip.volume;
            clip.source.pitch = clip.pitch;
            clip.source.loop = clip.loop;
            clip.source.playOnAwake = false;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
       Play("Music");
       Play("Ambience");
    }

    private void OnEnable()
    {
        PlayAudio += Play;
    }

    private void OnDisable()
    {
        PlayAudio -= Play;
    }

    public void Play(string clipName)
    {
        AudioClipProperties clip = Array.Find(clipProperties, clipProperty => clipProperty.clipName == clipName);
        
        if (clip == null)
        {
            return;
        }
        clip.source.Play();
    }

   
}




