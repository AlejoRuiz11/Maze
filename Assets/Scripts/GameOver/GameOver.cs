using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject victoryPanel;  
    public GameObject defeatPanel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        string gameResult = PlayerPrefs.GetString("GameResult");

        if (gameResult == "Victory")
        {
            victoryPanel.SetActive(true);
            defeatPanel.SetActive(false);
        }
        else if (gameResult == "Defeat")
        {
            defeatPanel.SetActive(true);
            victoryPanel.SetActive(false);
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
