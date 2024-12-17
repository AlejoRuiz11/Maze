using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetChildTextMeshPro : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    // Método para obtener el TextMeshPro hijo
    public TextMeshProUGUI GetTextMeshPro()
    {
        if (textMeshPro == null)
        {
            // Busca el TextMeshPro en los hijos si no está cacheado
            textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        }

        return textMeshPro;
    }
}
