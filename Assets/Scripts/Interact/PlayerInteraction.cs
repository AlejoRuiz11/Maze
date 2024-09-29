using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool[] llaves;

    private void Start()
    {
        llaves = new bool[1];
        llaves[0] = false;
    }

    public void Interactuar()
    {
        float interactRange = 3f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if(!interactable.Utilizado)
                {
                    interactable.Interactuar();
                }
            }
        }
    }

    public bool SomethingToInteract() // to show interaction hud
    {
        float interactRange = 3f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if(!interactable.Utilizado)
                {
                    return true;
                }
            }
        }
        return false;
    }




}
