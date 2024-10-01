using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour, IInteractable
{
    public bool Utilizado => used;
    private bool used = false;
    [SerializeField] private GameObject textUI;
    [SerializeField] private GameObject player;
    [SerializeField] private float seconds;
    private float rotationSpeed = 2f;
    
    private bool isTalking;
    public void Interactuar()
    {
        if(!textUI.activeInHierarchy)
        {
            isTalking = true;
            StartCoroutine(Talk());
            StartCoroutine(FacePlayer());
            //StartCoroutine(RotateTowardsPlayer());
        }
    }

    private IEnumerator Talk()
    {
        textUI.SetActive(true);
        yield return new WaitForSeconds(seconds);
        isTalking = false;
        textUI.SetActive(false);
        
    }

    private IEnumerator RotateTowardsPlayer()
    {
        float elapsedTime = 0f;
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        while (elapsedTime < 2)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, elapsedTime / 2);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    private IEnumerator FacePlayer()
    {
        while (isTalking)
        {
            Vector3 directionToPlayer = player.transform.position - textUI.transform.position;
            directionToPlayer.y = 0;

            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            textUI.transform.rotation = Quaternion.Slerp(textUI.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime * 2);

            yield return null;
        }
    }
}
