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

    GameOverManager gameOverManager;

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
        Player.transform.rotation = Quaternion.Euler(Player.transform.eulerAngles.x, 0, Player.transform.eulerAngles.z);
        characterInput.enabled = false;
        characterRun.Move(Vector3.forward);
        camaraJugador1.SetActive(false);
        camaraJugador2.SetActive(false);
        camaraFinal.SetActive(true);
        Coroutine a = StartCoroutine(Mover());
        yield return new WaitForSeconds(12f);
        StopCoroutine(a);
        gameOverManager.TriggerVictory();
    }

    private IEnumerator Mover()
    {
        float speed = 5f; // Velocidad de movimiento del jugador
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
