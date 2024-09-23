using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFeather : MonoBehaviour
{
    public bool inMaze = false;
    [SerializeField] private GameObject cuerpoGO;
    [SerializeField] private GameObject yellowFeather;
    [SerializeField] private GameObject Egg;

    public void InstantiateFeather(bool yellow)
    {
        if(inMaze)
        {
            Vector3 positionLeather = cuerpoGO.transform.position + new Vector3(0,0.5f,0);
            Vector3 positionEgg = cuerpoGO.transform.position + new Vector3(0,-0.3f,0);
            if(yellow)
            {
                Instantiate(yellowFeather, positionLeather, cuerpoGO.transform.rotation);
            }
            else
            {
                Instantiate(Egg, positionEgg, Quaternion.LookRotation(Vector3.up));
            }
        }        
    }

}
