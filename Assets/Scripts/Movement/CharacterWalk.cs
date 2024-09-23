using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalk : MonoBehaviour, IMovable
{
    public float Speed => speed;
    [SerializeField] private float speed = 6;
    private CharacterSoundManager characterSoundManager;
    private CharacterJump characterJump;
    private Rigidbody rb; // Referencia al Rigidbody

    private CharacterController characterController;

    private void Start()
    {
        characterSoundManager = GetComponent<CharacterSoundManager>();
        characterJump = GetComponent<CharacterJump>();
        //rb = GetComponent<Rigidbody>(); 
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        //transform.position += direction * speed * Time.deltaTime;
        
        if(characterJump.IsJumping)
        {
            //rb.drag = 0;
            //rb.AddForce(direction.normalized * speed * 0.1f, ForceMode.Force);
            //transform.position += direction * speed * Time.deltaTime;
            characterController.Move(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
            //rb.drag = 8;
            //rb.AddForce(direction.normalized * speed * 5f, ForceMode.Force);
            //rb.velocity = direction.normalized * speed;
            //rb.AddForce(direction.normalized * speed * 0.1f, ForceMode.VelocityChange);
            //transform.position += direction * speed * Time.deltaTime;
            //direction.y =0;
            characterController.Move(direction.normalized * speed * Time.deltaTime);
        }
        
        

        // rotar camara
        float rotateSpeed = 3.5f;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    public void ReproducirSonido()
    {
        if(characterSoundManager.getCurrentClip() != characterSoundManager.walkSound || !characterSoundManager.IsPlaying())
        {
            characterSoundManager.CambiarVolumen(0.5f);
            characterSoundManager.SetLoop(true);
            characterSoundManager.cambiarClip(characterSoundManager.walkSound);
            characterSoundManager.Play();
        }
    }

    public void PararSonido()
    {
        if (characterSoundManager == null) return;
        characterSoundManager.SetLoop(false);
        if(characterSoundManager.getCurrentClip() == characterSoundManager.walkSound || characterSoundManager.getCurrentClip() == characterSoundManager.runSound)
        {
            characterSoundManager.Stop();
        }
    }
}
