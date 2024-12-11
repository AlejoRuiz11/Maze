using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    private bool hasTriggeredFall = false;  

    void OnCollisionEnter(Collision collision)
    {
        if (!hasTriggeredFall)
        {
            hasTriggeredFall = true;
            EventManager.TriggerBoulderFall(); 
        }

        if (collision.collider.CompareTag("Player"))
        {
            EventManager.TriggerPlayerHit(); 
        }
    }
}
