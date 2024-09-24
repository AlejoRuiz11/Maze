using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalk : MonoBehaviour, IMovable
{
    public float Speed => speed;
    [SerializeField] private float speed = 6;
    private CharacterSoundManager characterSoundManager;
    private CharacterJump characterJump;

    private CharacterController characterController;

    private void Start()
    {
        characterSoundManager = GetComponent<CharacterSoundManager>();
        characterJump = GetComponent<CharacterJump>();
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        //transform.position += direction * speed * Time.deltaTime;
        
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
