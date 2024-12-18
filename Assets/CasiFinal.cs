using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasiFinal : MonoBehaviour
{
    [SerializeField] private GameObject NPCSExterior;
    // Start is called before the first frame update
    void Start()
    {
        NPCSExterior.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        NPCSExterior.SetActive(true);
    }
    
}
