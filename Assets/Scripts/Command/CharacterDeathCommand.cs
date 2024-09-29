using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeathCommand : ICommand
{
    private GameOverManager gameOverManager;

    public CharacterDeathCommand(GameOverManager gameOverManager)
    {
        this.gameOverManager = gameOverManager;
    }

    public void Do()
    {
        gameOverManager.TriggerDefeat();
    }

    public void Undo()
    {
        
    }
}
