using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLadoALado : MonoBehaviour
{
    public float velocidad = 2f;
    private bool moviendoHaciaPositivo = true;
    private float posicionInicialZ;
    private float diferencia = 100f; 

    void Start()
    {
        posicionInicialZ = transform.position.z;
    }

    void Update()
    {
        if (moviendoHaciaPositivo)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            if (transform.position.z >= posicionInicialZ + diferencia)
            {
                moviendoHaciaPositivo = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);
            if (transform.position.z <= posicionInicialZ)
            {
                moviendoHaciaPositivo = true;
            }
        }
    }

}
