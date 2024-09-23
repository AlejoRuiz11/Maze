using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    private float fallSpeed = 0.3f;
    private bool grounded = false;
    //[SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        StartCoroutine(Drop());
    }

    public IEnumerator Drop()
    {
        int groundLayer = LayerMask.GetMask("Ground");
        float hitDistance;
        if(transform.localScale.y>2) hitDistance = 0.1f;
        else hitDistance = 0.02f;


        while (!grounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                if (hit.distance > hitDistance)
                {
                    transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
                }
                else
                {
                    grounded = true;
                    transform.position = new Vector3(transform.position.x, transform.localScale.y * 0.01f, transform.position.z);
                }
            }
            yield return null;
        }
    }
}
