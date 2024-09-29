using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 10f;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed* Time.deltaTime);
    }
}
