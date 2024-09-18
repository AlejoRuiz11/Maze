using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRun : MonoBehaviour, IMovable
{
    public float Speed => speed;
    [SerializeField] private float speed = 12;
    private CharacterJump characterJump;
    private CharacterSoundManager characterSoundManager;
    private Rigidbody rb; // Referencia al Rigidbody
    private CharacterController characterController;

    private void Start()
    {
        characterSoundManager = GetComponent<CharacterSoundManager>();
        characterJump = GetComponent<CharacterJump>();
        //rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        
        if(characterJump.IsJumping)
        {
            //rb.drag = 0;
            //rb.AddForce(direction.normalized * speed * 0.1f, ForceMode.Force);
            characterController.Move(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
            //rb.drag = 8;
            //rb.AddForce(direction.normalized * speed * 5f, ForceMode.Force);
            //transform.position += direction * speed * Time.deltaTime;
            characterController.Move(direction.normalized * speed * Time.deltaTime);
        }

        
        // rotar camara
        float rotateSpeed = 3.5f;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        
    }


    public void ReproducirSonido()
    {
        if(characterSoundManager.getCurrentClip() != characterSoundManager.runSound || !characterSoundManager.IsPlaying())
        {
            characterSoundManager.CambiarVolumen(0.8f);
            characterSoundManager.SetLoop(true);
            characterSoundManager.cambiarClip(characterSoundManager.runSound);
            characterSoundManager.Play();
        }
    }

    public void PararSonido()
    {
        characterSoundManager.SetLoop(false);
        if(characterSoundManager.getCurrentClip() == characterSoundManager.walkSound || characterSoundManager.getCurrentClip() == characterSoundManager.runSound)
        {
            characterSoundManager.Stop();
        }
    }
}
