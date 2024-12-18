using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjetivosHud : MonoBehaviour
{
    [Header("Prefab del objetivo")]
    public GameObject objetivoPrefab; // Prefab de la imagen con TextMeshPro como hijo

    private List<GameObject> objetivos = new List<GameObject>(); // Lista de objetivos instanciados

    /// <summary>
    /// Agrega un nuevo objetivo.
    /// </summary>
    /// <param name="texto">Texto del objetivo.</param>
    public void AgregarObjetivo(string texto)
{
    if (objetivoPrefab == null)
    {
        Debug.LogError("No se ha asignado el prefab del objetivo.");
        return;
    }

    // Verificar si el objetivo ya existe
    bool existe = objetivos.Exists(obj =>
    {
        TextMeshProUGUI textMeshPro = obj.GetComponentInChildren<TextMeshProUGUI>();
        return textMeshPro != null && textMeshPro.text == texto;
    });

    if (existe)
    {
        Debug.LogWarning($"El objetivo con el texto '{texto}' ya existe y no se añadirá.");
        return;
    }

    // Instanciar el prefab como hijo de este objeto
    GameObject nuevoObjetivo = Instantiate(objetivoPrefab, transform);
    nuevoObjetivo.name = "Objetivo: " + texto;

    // Obtener el TextMeshPro y asignar el texto
    TextMeshProUGUI textMeshProNuevo = nuevoObjetivo.GetComponentInChildren<TextMeshProUGUI>();
    if (textMeshProNuevo != null)
    {
        textMeshProNuevo.text = texto;
    }

    // Añadir a la lista
    objetivos.Add(nuevoObjetivo);
    ForceUpdateLayout();

    // Iniciar la corrutina para el objetivo auxiliar
    StartCoroutine(ObjetivoAux());
}

private IEnumerator ObjetivoAux()
{
    // Crear el objetivo auxiliar
    GameObject objetivoAux = Instantiate(objetivoPrefab, transform);
    objetivoAux.name = "Objetivo Auxiliar";

    // Configurar el texto del objetivo auxiliar
    TextMeshProUGUI textMeshProAux = objetivoAux.GetComponentInChildren<TextMeshProUGUI>();
    if (textMeshProAux != null)
    {
        textMeshProAux.text = "Auxiliar";
    }

    // Esperar 1 segundo
    yield return new WaitForSeconds(0.015f);

    // Eliminar el objetivo auxiliar
    Destroy(objetivoAux);

    // Forzar la actualización del layout
    ForceUpdateLayout();
}

    /// <summary>
    /// Elimina un objetivo específico.
    /// </summary>
    /// <param name="texto">Texto del objetivo a eliminar.</param>
    public void EliminarObjetivo(string texto)
    {
        // Buscar el objetivo con el texto especificado
        GameObject objetivoAEliminar = objetivos.Find(obj => 
        {
            TextMeshProUGUI textMeshPro = obj.GetComponentInChildren<TextMeshProUGUI>();
            return textMeshPro != null && textMeshPro.text == texto;
        });

        if (objetivoAEliminar != null)
        {
            objetivos.Remove(objetivoAEliminar);
            Destroy(objetivoAEliminar);
        }
        else
        {
            Debug.LogWarning($"No se encontró un objetivo con el texto: {texto}");
        }
    }

    /// <summary>
    /// Marca un objetivo como completado, lo tacha y lo elimina después de 2 segundos.
    /// </summary>
    /// <param name="texto">Texto del objetivo a marcar como completado.</param>
    /// 

    public void EliminarTodosLosObjetivos()
    {
        foreach (var objetivo in objetivos)
        {
            Destroy(objetivo);
        }
        objetivos.Clear();
    }

    private IEnumerator ElimTodo()
    {
        yield return new WaitForSeconds(1f);
        foreach (var objetivo in objetivos)
        {
            Destroy(objetivo);
        }
        objetivos.Clear();
    }

    public IEnumerator MarcarCompletado(string texto)
    {
        // Buscar el objetivo con el texto especificado
        GameObject objetivoACompletar = objetivos.Find(obj => 
        {
            TextMeshProUGUI textMeshPro = obj.GetComponentInChildren<TextMeshProUGUI>();
            return textMeshPro != null && textMeshPro.text == texto;
        });

        if (objetivoACompletar != null)
        {
            // Cambiar el color del texto y tacharlo
            TextMeshProUGUI textMeshPro = objetivoACompletar.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.color = Color.green; // Cambiar color a verde
                textMeshPro.fontStyle |= FontStyles.Strikethrough; // Añadir tachado
            }

            // Esperar 2 segundos
            yield return new WaitForSeconds(2);

            // Eliminar el objetivo
            objetivos.Remove(objetivoACompletar);
            Destroy(objetivoACompletar);
        }
        else
        {
            Debug.LogWarning($"No se encontró un objetivo con el texto: {texto}");
        }
    }



    public void MostrarHUD()
    {
        gameObject.SetActive(true);
    }

    public void OcultarHUD()
    {
        // Desactiva el GameObject que contiene este script
        gameObject.SetActive(false);
    }

    private void ForceUpdateLayout()
    {
        // Obtener el componente LayoutGroup del contenedor
        LayoutGroup layoutGroup = GetComponent<LayoutGroup>();
        if (layoutGroup != null)
        {
            // Forzar la reconstrucción inmediata del layout
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }
    }

}
