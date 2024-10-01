using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRun : MonoBehaviour, IMovable
{
    public float Speed => speed;
    public float speed = 12;
    private CharacterJump characterJump;
    private CharacterSoundManager characterSoundManager;
    private CharacterController characterController;

    private void Start()
    {
        characterSoundManager = GetComponent<CharacterSoundManager>();
        characterJump = GetComponent<CharacterJump>();
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        
        if(characterJump.IsJumping)
        {
            characterController.Move(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
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
            characterSoundManager.CambiarVolumen(0.25f);
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
