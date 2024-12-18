using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private GameObject camara1;
    [SerializeField] private GameObject camara2;
    [SerializeField] private GameObject camara3;
    [SerializeField] private GameObject camara4;
    [SerializeField] private GameObject camara5;
    [SerializeField] private CharacterInput characterInput;
    [SerializeField] private GameObject camaraPrincipal;
    [SerializeField] private AudioSource audioSourcePresentador;
    [SerializeField] private GameObject skipGO;
    private bool aux = false;
    private bool aux1 = false;

    private Coroutine coroutine;

    void Start()
    {
        camara1.SetActive(false);
        camara2.SetActive(false);
        camara3.SetActive(false);
        camara4.SetActive(false);
        camara5.SetActive(false);

        camaraPrincipal.SetActive(false);
        characterInput.enabled = false;
        coroutine = StartCoroutine(StartIntro());
    }

    private void Update()
    {
        if(!aux)
        {
            if(Input.anyKeyDown && aux1)
            {
                if(coroutine != null)
                {
                    PararCorutina();
                }
            }
        }
    }

    private void PararCorutina()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            characterInput.enabled = true;
            camara1.SetActive(false);
            camara2.SetActive(false);
            camara3.SetActive(false);
            camara4.SetActive(false);
            camara5.SetActive(false);
            audioSourcePresentador.Stop();
            skipGO.SetActive(false);
            camaraPrincipal.SetActive(true);
            aux = true;
        }
    }

    private IEnumerator StartIntro()
    {
        // 1:05
        camara1.SetActive(true);
        Coroutine a = StartCoroutine(Mover(camara1,3.5f,Vector3.back));
        yield return new WaitForSeconds(5f); //55
        skipGO.SetActive(true);
        aux1 = true;    
        yield return new WaitForSeconds(5f); //55
        StopCoroutine(a);
        camara1.SetActive(false);
        camara2.SetActive(true);
        Coroutine b = StartCoroutine(Mover(camara2,4f,Vector3.left));
        yield return new WaitForSeconds(10f); //45
        StopCoroutine(b);
        camara2.SetActive(false);
        camara3.SetActive(true);
        Coroutine c = StartCoroutine(Mover(camara3,8f,Vector3.forward));
        yield return new WaitForSeconds(13f); //32
        StopCoroutine(c);
        camara3.SetActive(false);
        //***********
        
        camara4.SetActive(true);
        Coroutine d = StartCoroutine(Mover(camara4,8f,Vector3.forward));
        yield return new WaitForSeconds(16f); //32
        StopCoroutine(d);
        camara4.SetActive(false);
        camara5.SetActive(true);
        yield return new WaitForSeconds(16f); //32
        //StopCoroutine(e);
        camara5.SetActive(false);


        yield return new WaitForSeconds(1f);
        PararCorutina();
    }

    private IEnumerator Mover(GameObject camarita, float speed1, Vector3 direction1)
    {
        float speed = speed1;
        //Vector3 direction = Vector3.forward;
        Vector3 direction = direction1;
        while (true)
        {
            camarita.transform.Translate(direction * speed * Time.deltaTime);
            yield return null;
        }
    }
}