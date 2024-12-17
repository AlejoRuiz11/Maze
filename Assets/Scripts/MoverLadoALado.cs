using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLadoALado : MonoBehaviour
{
    public float velocidad = 2f;  // Velocidad del movimiento
    private bool moviendoHaciaPositivo = true;  // Dirección del movimiento

    void Update()
    {
        // Movimiento en el eje Z
        if (moviendoHaciaPositivo)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            if (transform.position.z >= 100f)
            {
                moviendoHaciaPositivo = false;  // Cambiar dirección
            }
        }
        else
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);
            if (transform.position.z <= -100f)
            {
                moviendoHaciaPositivo = true;  // Cambiar dirección
            }
        }
    }
}
