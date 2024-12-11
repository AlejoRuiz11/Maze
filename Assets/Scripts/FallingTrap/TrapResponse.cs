using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapResponse : MonoBehaviour
{
    public AudioSource audioSource;


    void OnEnable()
    {
        EventManager.OnTrapTriggered += ActivateTrap;
    }

    void OnDisable()
    {
        EventManager.OnTrapTriggered -= ActivateTrap;
    }

    void ActivateTrap()
    {

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
