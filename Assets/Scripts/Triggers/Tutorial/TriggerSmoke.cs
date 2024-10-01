using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSmoke : MonoBehaviour
{
    [SerializeField] private GameObject Smoke1;
    [SerializeField] private GameObject Smoke2;

    private void OnTriggerEnter(Collider collider)
    {
        IMovable movable = collider.GetComponent<IMovable>();
        if(movable!=null)
        {
            StartCoroutine(ActivateSmoke());
        }    
    }
    
    private IEnumerator ActivateSmoke()
    {
        yield return new WaitForSeconds(2f);
        Smoke1.SetActive(true);
        Smoke2.SetActive(true);
    }

}
