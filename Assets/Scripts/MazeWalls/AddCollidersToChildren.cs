using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollidersToChildren : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Collider>() == null)
            {
                child.gameObject.AddComponent<BoxCollider>();
            }
        }
    }
}
