using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public Transform laserEnd;               
    public TrapActivator trapActivator;      

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 
    }

    void Update()
    {
        Debug.DrawRay(transform.position, laserEnd.position - transform.position, Color.red);

        lineRenderer.SetPosition(0, transform.position);    
        lineRenderer.SetPosition(1, laserEnd.position);     

        Ray ray = new Ray(transform.position, laserEnd.position - transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Vector3.Distance(transform.position, laserEnd.position)))
        {

            if (hit.collider.CompareTag("Player"))
            {
                trapActivator.ActivateTrap();
            }
        }
    }
}
