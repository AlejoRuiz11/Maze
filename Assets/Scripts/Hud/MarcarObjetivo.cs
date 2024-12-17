using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcarObjetivo : MonoBehaviour
{
    [Header("Referencia al HUD de objetivos")]
    public ObjetivosHud objetivosHud; // Referencia al script ObjetivosHud

    [Header("Configuración de objetivos")]
    [Tooltip("Array que indica si el objetivo debe añadirse (true) o eliminarse (false).")]
    public bool[] acciones; // Array de booleanos: true = añadir, false = eliminar

    [Tooltip("Array de textos de los objetivos correspondientes a las acciones.")]
    public string[] textosObjetivos; // Array de textos de los objetivos

    private bool yaSeAsigno;

    /// <summary>
    /// Marca los objetivos al interactuar con el NPC.
    /// </summary>
    public void Marcar()
    {
        if(!yaSeAsigno)
        {
            if (objetivosHud == null)
            {
                Debug.LogError("No se ha asignado el HUD de objetivos.");
                return;
            }

            if (acciones.Length != textosObjetivos.Length)
            {
                Debug.LogError("Los arrays 'acciones' y 'textosObjetivos' deben tener el mismo tamaño.");
                return;
            }

            // Iterar sobre los arrays y realizar las acciones correspondientes
            for (int i = 0; i < acciones.Length; i++)
            {
                if (textosObjetivos[i] == "eliminartodo")
                {
                    objetivosHud.EliminarTodosLosObjetivos();
                }
                if (acciones[i])
                {
                    // Añadir el objetivo
                    objetivosHud.AgregarObjetivo(textosObjetivos[i]);
                }
                else
                {
                    // Eliminar el objetivo
                    //objetivosHud.EliminarObjetivo(textosObjetivos[i]);
                    StartCoroutine(objetivosHud.MarcarCompletado(textosObjetivos[i]));
                }
            }
            yaSeAsigno = true;
        }
        
    }
}
