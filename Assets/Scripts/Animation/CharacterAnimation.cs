using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private CharacterInput characterInput;
    [SerializeField] private CharacterJump characterJump;
    [SerializeField] private ParticleSystem particlesRun;

    private const string IS_MOVING = "IsMoving";
    private const string IS_WALKING = "IsWalking";
    private const string IS_JUMPING = "IsJumping";
    private const string IS_GROUNDED = "IsGrounded";

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool(IS_MOVING, characterInput.IsMoving());
        animator.SetBool(IS_WALKING, characterInput.IsWalking());
        animator.SetBool(IS_JUMPING, characterInput.IsJumping());
        animator.SetBool(IS_GROUNDED, characterJump.IsGrounded());
        if(characterJump.IsGrounded() && !characterInput.IsWalking() && characterInput.IsMoving())
        {
            //particlesRun.SetActive(true);
            ToggleEmission(true);
        }
        else
        {
            ToggleEmission(false);
            //particlesRun.SetActive(false);
        }
    }

    public void ToggleEmission(bool emit)
    {
        var emission = particlesRun.emission;
        emission.enabled = emit; // Activa o desactiva la emisión de partículas nuevas
    }

}
