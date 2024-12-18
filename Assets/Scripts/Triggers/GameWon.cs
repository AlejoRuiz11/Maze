using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private CharacterInput characterInput;
    [SerializeField] private CharacterRun characterRun;
    [SerializeField] private GameObject camaraJugador2;
    [SerializeField] private GameObject camaraJugador1;
    [SerializeField] private GameObject camaraFinal;
    [SerializeField] private GameObject topImageGO;
    [SerializeField] private GameObject bottomImageGO;
    [SerializeField] ObjetivosHud objetivosUI;
    [SerializeField] GameObject minimapUI;
    [SerializeField] AudioSource EndingMusic;
    [SerializeField] AudioSource musicaFondo;
    GameOverManager gameOverManager;
    
    private float moveDistance = 200f;
    private float moveSpeed = 105f;

    void Start()
    {
        gameOverManager = FindAnyObjectByType<GameOverManager>();
        StartCoroutine(instanciarRun());
    }

    private IEnumerator instanciarRun()
    {
        yield return 5;
        float aux = 0;
        while(aux < 9)
        {
            characterRun = Player.GetComponent<CharacterRun>();        
            yield return new WaitForSeconds(10f);
            aux++;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Final());
    }

    private IEnumerator Final()
    {
        StartCoroutine(FocusEnding());
        EndingMusic.Play();
        musicaFondo.Stop();
        //camaraJugador1.SetActive(false);
        //camaraJugador2.SetActive(false);
        //camaraFinal.SetActive(true);
        Coroutine a = StartCoroutine(Mover());
        yield return new WaitForSeconds(17f);
        StopCoroutine(a);
        gameOverManager.TriggerVictory();
    }


    private IEnumerator FocusEnding()
    {
        Player.transform.rotation = Quaternion.Euler(Player.transform.eulerAngles.x, 0, Player.transform.eulerAngles.z);
        characterInput.enabled = false;
        characterRun.Move(Vector3.forward);
        GameObject cameraa;
        if(camaraJugador1.activeInHierarchy) cameraa = camaraJugador1;
        else cameraa = camaraJugador2;

        FocusObject focusTimeCoin = new FocusObject(cameraa, Player, camaraFinal);
        focusTimeCoin.Do();
        //objetivosUI.OcultarHUD();
        RectTransform topImage = topImageGO.GetComponent<RectTransform>();
        RectTransform bottomImage = bottomImageGO.GetComponent<RectTransform>();
        float aux = bottomImage.anchoredPosition.y; // -650
        bool finished = false;
        objetivosUI.OcultarHUD();
        minimapUI.SetActive(false);
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
    }


    private IEnumerator Mover()
    {
        float speed = 3.5f; // Velocidad de movimiento del jugador
        Vector3 direction = Vector3.forward; // Dirección en el eje Z positivo

        while (true)
        {
            // Mover el jugador manualmente hacia adelante
            Player.transform.Translate(direction * speed * Time.deltaTime);

            // Esperar al siguiente frame
            yield return null;
        }
    }

}
