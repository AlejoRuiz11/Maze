using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarLlave : MonoBehaviour
{
    private float spinSpeed = 100f;

    private void Update() {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

}
