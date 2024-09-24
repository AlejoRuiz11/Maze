using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{
    GameOverManager gameOverManager;
    void Start()
    {
        gameOverManager = FindAnyObjectByType<GameOverManager>();
    }

 
    private void OnTriggerEnter(Collider other)
    {
        gameOverManager.TriggerVictory();
    }

}
