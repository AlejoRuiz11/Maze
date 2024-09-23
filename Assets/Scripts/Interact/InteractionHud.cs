using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHud : MonoBehaviour
{
    [SerializeField] private GameObject playerGO;
    [SerializeField] private GameObject interactHud;
    private PlayerInteraction playerInteraction;
    private void Start() {
        playerInteraction = playerGO.GetComponent<PlayerInteraction>();
    }
    void Update()
    {
        if(playerInteraction.SomethingToInteract())
        {
            interactHud.SetActive(true);
        }
        else
        {
            interactHud.SetActive(false);
        }
    }
}
