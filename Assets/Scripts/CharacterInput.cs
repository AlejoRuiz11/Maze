using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterInput : MonoBehaviour
{

    private string RUN_MOVEMENT_STRATEGY = "CharacterRun";
    private string WALK_MOVEMENT_STRATEGY = "CharacterWalk";

    private CharacterWalk characterWalk;
    private CharacterRun characterRun;
    private PlayerInteraction playerInteraction;
    private IMovable movementLogic;

    private CharacterJump characterJump;
    private bool camaritaAux = false;
    [SerializeField] private Transform cam;
    //private CharacterMovement characterMovement;

    [SerializeField] private KeyCode forward = KeyCode.W;
    [SerializeField] private KeyCode back = KeyCode.S;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode sprint = KeyCode.LeftShift;
    [SerializeField] private KeyCode jump = KeyCode.Space;
    [SerializeField] private KeyCode cambiarCamara= KeyCode.Tab;
    [SerializeField] private KeyCode interactuar= KeyCode.E;

    // CAMARAS

    [SerializeField] private GameObject camaraPrimeraPersona;
    [SerializeField] private GameObject camaraTerceraPersona;

    // Mesh renderer de cabeza y cuerpo

    private GameObject cabeza;
    private GameObject cuerpo;


    private void Start()
    {
        AddDynamicComponent(WALK_MOVEMENT_STRATEGY);
        AddDynamicComponent(RUN_MOVEMENT_STRATEGY);

        characterWalk = GetComponent<CharacterWalk>();
        characterRun = GetComponent<CharacterRun>();
        characterJump = GetComponent<CharacterJump>();
        playerInteraction = GetComponent<PlayerInteraction>();

        movementLogic = characterWalk;

        camaraPrimeraPersona.SetActive(true);
        camaraTerceraPersona.SetActive(false);
        camaritaAux = false; // false == primera persona

        cabeza = transform.Find("Cabeza")?.gameObject;
        cuerpo = transform.Find("Cuerpo")?.gameObject;

        cabeza.SetActive(false);
        cuerpo.SetActive(false);
    }

    private void Update() {

        // 
        
        Vector3 forwardDir = cam.forward;
        Vector3 rightDir = cam.right;
        

        //Vector3 forwardDir = transform.forward;
        //Vector3 rightDir = transform.right;

        forwardDir.y = 0;
        rightDir.y = 0;

        // Normaliza los vectores
        forwardDir.Normalize();
        rightDir.Normalize();

        if(Input.GetKey(forward)) movementLogic.Move(forwardDir);
        if(Input.GetKey(back)) movementLogic.Move(-forwardDir);
        if(Input.GetKey(left)) movementLogic.Move(-rightDir);
        if(Input.GetKey(right)) movementLogic.Move(rightDir);

        if(Input.GetKeyDown(sprint)) movementLogic = characterRun;
        if(Input.GetKeyUp(sprint)) movementLogic = characterWalk;

        if((Input.GetKey(forward)||Input.GetKey(back)||Input.GetKey(left)||Input.GetKey(right)) && !characterJump.IsJumping)
        {
            movementLogic.ReproducirSonido();
        }
        else
        {
            movementLogic.PararSonido();
        }

        if(Input.GetKey(jump)) characterJump.Jump();

        if(Input.GetKeyDown(cambiarCamara))
        {
            StartCoroutine(CambiarCamara());
            //CambiarCamara();
        }
        if(Input.GetKeyDown(interactuar))
        {
            playerInteraction.Interactuar();
        }
    }

    private IEnumerator CambiarCamara()
    {
        if(camaritaAux)
        {
            camaraPrimeraPersona.SetActive(true);
            camaraTerceraPersona.SetActive(false);
            camaritaAux = false;
            yield return new WaitForSeconds(0.5f);
            Debug.Log("aaaa");
            cabeza.SetActive(false);
            cuerpo.SetActive(false);
        }
        else
        {
            camaraPrimeraPersona.SetActive(false);
            camaraTerceraPersona.SetActive(true);
            camaritaAux = true;
            yield return new WaitForSeconds(0.5f);
            Debug.Log("bbbb");
            cabeza.SetActive(true);
            cuerpo.SetActive(true);
        }
    }

    private void AddDynamicComponent(string name)
    {
        Type newComponent = Type.GetType($"{name}");
        if (newComponent != null)
        {
            Debug.LogWarning($"Component '{name}' added!");
            gameObject.AddComponent(newComponent);
        }
        else
        {
            Debug.LogWarning($"Component '{name}' not found!");
        }
    }

}
