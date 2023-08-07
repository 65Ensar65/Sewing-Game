using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSound : Base
{
    public AudioClip audioClip;
    private AudioSource audioSource; 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
