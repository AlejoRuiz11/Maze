using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManInteraction : MonoBehaviour, IInteractable
{
    public bool Utilizado => used;
    private bool used = false;
    [SerializeField] private GameObject textUI;

    public void Interactuar()
    {
        StartCoroutine(Talk());
    }

    private IEnumerator Talk()
    {
        textUI.SetActive(true);
        yield return new WaitForSeconds(6);
        textUI.SetActive(false);
        
    }

}
