using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip walkSound;
    public AudioClip runSound;

    public void cambiarClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
       audioSource.Play();
    }

    public void PlayOneShot()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public void SetLoop(bool a)
    {
        audioSource.loop = a;
    }

    public AudioClip getCurrentClip()
    {
        return audioSource.clip;
    }

    public void CambiarVolumen(float volumen)
    {
        audioSource.volume = volumen;
    }

}
