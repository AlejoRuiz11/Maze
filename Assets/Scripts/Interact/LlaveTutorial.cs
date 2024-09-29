using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveTutorial : MonoBehaviour, IInteractable
{
    public bool Utilizado => used;
    private bool used = false;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private GameObject trigger;

    public void Interactuar()
    {
        PlayerInteraction playerInteraction = playerGO.GetComponent<PlayerInteraction>();
        trigger.SetActive(true);
        playerInteraction.llaves[0] = true;
        Destroy(gameObject);
    }
}
