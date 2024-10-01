using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotonPuertaInicio : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject informationUI;
    [SerializeField] private GameObject audioSourceGO;

    //
    [SerializeField] private GameObject objectCamera;
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private GameObject topImageGO;
    [SerializeField] private GameObject bottomImageGO;



    private GameObject cameraa;
    private PlayerInteraction playerInteraction;
    private float velocidad = 1.4f;
    public bool used = false;

    public bool Utilizado => used;
    
    private float moveDistance = 200f;
    private float moveSpeed = 105f;

    private void Start() {
        playerInteraction = player.GetComponent<PlayerInteraction>();
    }

    public void Interactuar()
    {
        if(!Utilizado)
        {
            if(playerInteraction.llaves[0])
            {
                used = true;
                StartCoroutine(SubirPuerta());
                StartCoroutine(FocusGate());
            }
            else
            {
                StartCoroutine(NeedKeyMessage());
            }
        }
    }

    private IEnumerator NeedKeyMessage()
    {
        if(!informationUI.activeInHierarchy)
        {
            informationUI.SetActive(true);
            informationUI.GetComponentInChildren<TextMeshProUGUI>().SetText("Necesitas una llave para abrir esta puerta");
            yield return new WaitForSeconds(4);
            informationUI.SetActive(false);
        }
    }

    private IEnumerator SubirPuerta()
    {
        AudioSource audioSource = audioSourceGO.GetComponent<AudioSource>();
        audioSource.Play();

        Transform transformPuertica = puerta.GetComponent<Transform>();
        float yFinal = transformPuertica.position.y + 20;
        while(yFinal - transformPuertica.position.y > 2)
        {
            transformPuertica.position += new Vector3(0, velocidad * Time.deltaTime, 0);
            yield return null;
        }

    }

    private IEnumerator FocusGate()
    {
        if(firstPersonCamera.activeInHierarchy) cameraa = firstPersonCamera;
        else cameraa = thirdPersonCamera;

        FocusObject focusTimeCoin = new FocusObject(cameraa, player, objectCamera);
        focusTimeCoin.Do();
        
        RectTransform topImage = topImageGO.GetComponent<RectTransform>();
        RectTransform bottomImage = bottomImageGO.GetComponent<RectTransform>();
        float aux = bottomImage.anchoredPosition.y; // -650
        bool finished = false;
        while(!finished)
        {
            topImage.anchoredPosition += new Vector2(0, -moveSpeed * Time.deltaTime);
            bottomImage.anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            if((aux + moveDistance) < bottomImage.anchoredPosition.y)
            {
                finished = true;
            }
            yield return null;
        }

        yield return new WaitForSeconds(6);
        focusTimeCoin.Undo();
        float aux2 = bottomImage.anchoredPosition.y; // -650
        finished = false;
        aux = bottomImage.anchoredPosition.y;
        while(!finished)
        {
            topImage.anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            bottomImage.anchoredPosition += new Vector2(0, -moveSpeed * Time.deltaTime);
            if((aux2 - 200) > bottomImage.anchoredPosition.y)
            {
                finished = true;
            }
            yield return null;
        }
    }
    


}
