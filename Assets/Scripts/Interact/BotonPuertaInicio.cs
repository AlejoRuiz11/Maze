using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuertaInicio : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject player;
    private PlayerInteraction playerInteraction;
    private float velocidad = 1f;
    public bool used = false;

    public bool Utilizado => used;

    private void Start() {
        playerInteraction = player.GetComponent<PlayerInteraction>();
    }

    public void Interactuar()
    {
        if(!Utilizado && playerInteraction.llaves[0])
        {
            used = true;
            StartCoroutine(SubirPuerta());
        }
    }

    private IEnumerator SubirPuerta()
    {
        Transform transformPuertica = puerta.GetComponent<Transform>();
        float yFinal = transformPuertica.position.y + 20;

        while(yFinal - transformPuertica.position.y > 2)
        {
            transformPuertica.position += new Vector3(0, velocidad * Time.deltaTime, 0);
            yield return null;
        }
    }

}
