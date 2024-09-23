using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCoin : MonoBehaviour//, ICoinable
{
    [SerializeField] private GameObject countdownText;
    [SerializeField] private GameObject audioGO;
    private AudioManager audioManager;
    [SerializeField] private float time;

    private void Start() {
        audioManager = audioGO.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        IMovable movable = collider.gameObject.GetComponent<IMovable>();
        if(movable != null)
        {
            countdownText.GetComponent<Countdown>().remainingTime += time;
            if(time == 30)
            {
                audioManager.PlaySilverCoin();
            }
            else
            {
                audioManager.PlayGoldCoin();
            }
            Destroy(gameObject);
        }
    }
    
/*
    public void takeCoin()
    {
        throw new System.NotImplementedException();
    }*/
}
