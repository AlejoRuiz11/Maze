using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
   
    public void Interactuar()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interactuar();
            }
        }
    }
}
