using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioClipProperties
{
    public string clipName;
    public AudioClip clip;
    
    [HideInInspector]
    public AudioSource source;

    [Range(0f,1f)]
    public float volume;
    public float pitch;
    public bool loop;

}
