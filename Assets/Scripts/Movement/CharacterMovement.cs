using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float WalkSpeed => walkSpeed;

    public float RunSpeed => runSpeed;

    public bool IsRunning => isRunning;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool isRunning;


    public void Move(Vector3 direction)//, Vector3 directionPlayer)
    {
        if(isRunning)
        {
            transform.position += direction * runSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += direction * walkSpeed * Time.deltaTime;
        }
        // rotate the character when he moves
        //transform.forward = direction;
        //rotate(directionPlayer);
        float rotateSpeed = 3.5f;
        //transform.forward = Vector3.Slerp(transform.position, direction, Time.deltaTime * rotateSpeed);

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Interpola la rotación actual hacia la rotación deseada
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }


    public void changeSpeed(bool a)
    {
        isRunning = a;
    }

}
