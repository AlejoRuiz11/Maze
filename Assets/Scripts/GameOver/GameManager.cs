using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void TriggerVictory()
    {
        PlayerPrefs.SetString("GameResult", "Victory");
        SceneManager.LoadScene("GameOver");
    }

    public void TriggerDefeat()
    {
        PlayerPrefs.SetString("GameResult", "Defeat");
        SceneManager.LoadScene("GameOver");
    }
}
