using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntryMaze : MonoBehaviour
{
    [SerializeField] GameObject countdownText;
    [SerializeField] GameObject player;
    private DropFeather dropFeather;
    private void Start()
    {
        dropFeather = player.GetComponent<DropFeather>();    
    }

    private void OnTriggerEnter(Collider collider)
    {
        IMovable movable = collider.GetComponent<IMovable>();
        if(movable!=null)
        {
            countdownText.SetActive(true);
            dropFeather.inMaze = true;
            //countdownText.GetComponent<Countdown>().remainingTime += 60;
        }
    }
}
