using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuertaInicio : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject puerta;
    private float velocidad = 1f;
    private bool utilizado = false;

    public void Interactuar()
    {
        if(!utilizado)
        {
            utilizado = true;
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
