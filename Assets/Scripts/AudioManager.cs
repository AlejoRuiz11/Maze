using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource goldTimeCoin;
    [SerializeField] AudioSource silverTimeCoin;

    public void PlayGoldCoin()
    {
        goldTimeCoin.Play();
    }

    public void PlaySilverCoin()
    {
        silverTimeCoin.Play();
    }
}

