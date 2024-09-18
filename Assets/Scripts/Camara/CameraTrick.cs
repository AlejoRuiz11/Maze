using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraTrick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Jugador;
    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90,90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
        //Orientation.rotation


        transform.position = Jugador.transform.position + new Vector3(0,1.2f,0);

        
    }
}
