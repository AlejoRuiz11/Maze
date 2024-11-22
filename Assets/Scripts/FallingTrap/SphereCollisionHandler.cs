using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    public GameOverManager gameOverManager; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player hit by sphere. Game Over.");
            gameOverManager.TriggerDefeat(); 
        }
    }
}
