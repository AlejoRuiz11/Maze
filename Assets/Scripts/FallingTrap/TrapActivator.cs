using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    public Rigidbody fallingObject;   
    public MeshRenderer sphereRenderer; 

    void Start()
    {
        fallingObject.isKinematic = true;

        if (sphereRenderer != null)
        {
            sphereRenderer.enabled = false;
        }
    }

    public void ActivateTrap()
    {
        if (sphereRenderer != null)
        {
            sphereRenderer.enabled = true;
        }

        fallingObject.isKinematic = false;
    }
}
