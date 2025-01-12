using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip bgm;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        OnPlayBGM();
    }

    private void OnPlayBGM()
    {
        audioSource.clip = bgm; 
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        audioSource.Stop();
    }
}
