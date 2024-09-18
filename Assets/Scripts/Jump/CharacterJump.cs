using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour, IJumpable
{
    public Rigidbody Rb => rb;
    public float JumpForce => jumpForce;
    public bool IsJumping => isJumping;

    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer; // Capa que representa el suelo
    [SerializeField] private Transform groundCheck; // Punto para comprobar si el personaje está en el suelo
    [SerializeField] private float groundCheckRadius = 0.2f; // Radio de verificación del suelo

    [SerializeField] private AudioClip audioClip;
    private Rigidbody rb;
    
    private Vector3 velocity;
    private CharacterSoundManager characterSoundManager;
    private CharacterController characterController;
    private bool isJumping = false;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        characterSoundManager = GetComponent<CharacterSoundManager>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Verifica si el jugador está en el suelo usando CheckSphere
        //isJumping = false;
        isJumping = !Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
       
        if(IsJumping)
        {
            velocity.y -= gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
        else
        {
            velocity.y = jumpForce;
            //rb.drag = 0;
        }
    }

    public void Jump()
    {
        if (!isJumping)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            characterController.Move(velocity * Time.deltaTime);
            isJumping = true; // Marca al personaje como saltando
            ReproducirSonido();
            characterSoundManager.CambiarVolumen(0.2f);
        }
    }

    private void ReproducirSonido()
    {
        characterSoundManager.cambiarClip(audioClip);
        characterSoundManager.PlayOneShot();
    }

}
