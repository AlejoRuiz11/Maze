using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntryMaze : MonoBehaviour
{
    [SerializeField] GameObject countdownText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject minimapUI;
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
            minimapUI.SetActive(true);
            countdownText.SetActive(true);
            dropFeather.inMaze = true;
            minimap.SetActive(true);
            
            //countdownText.GetComponent<Countdown>().remainingTime += 60;
        }
    }
}
