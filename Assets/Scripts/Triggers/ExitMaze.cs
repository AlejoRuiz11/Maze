using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMaze : MonoBehaviour
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
            if(!(countdownText.GetComponent<Countdown>().remainingTime > 60))
            {
                countdownText.GetComponent<Countdown>().remainingTime = 60;
            }
            minimapUI.SetActive(false);
            countdownText.SetActive(false);
            dropFeather.inMaze = false;
            minimap.SetActive(false);
            
        }
    }
}
