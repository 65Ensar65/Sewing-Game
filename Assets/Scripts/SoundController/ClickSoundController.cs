using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundController : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public void GetSoundController()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
