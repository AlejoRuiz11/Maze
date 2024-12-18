using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource goldTimeCoin;
    [SerializeField] AudioSource AudioSourceMusic;
    [SerializeField] AudioSource silverTimeCoin;
    [SerializeField] AudioClip musicaFondo;
    [SerializeField] AudioClip musicaLaberinto;
    
    private void Start() {
        PlayLobbyMusic();
    }

    public void PlayGoldCoin()
    {
        goldTimeCoin.Play();
    }

    public void PlaySilverCoin()
    {
        silverTimeCoin.Play();
    }
    public void PlayMazeMusic()
    {
        AudioSourceMusic.clip = musicaLaberinto;
        AudioSourceMusic.Play();
    }

    public void PlayLobbyMusic()
    {
        AudioSourceMusic.clip = musicaFondo;
        AudioSourceMusic.Play();
    }

}

