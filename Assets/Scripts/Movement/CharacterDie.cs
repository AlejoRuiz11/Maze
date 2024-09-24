using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDie : MonoBehaviour
{
    private ICommand deathCommand;

    private void Start()
    {
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        deathCommand = new CharacterDeathCommand(gameOverManager);
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -5f)
        {
            deathCommand.Execute();
        }
    }
}
