using UnityEngine;

public class BoulderResponse : MonoBehaviour
{
    public GameOverManager gameOverManager;
    private AudioSource audioSource;
    void OnEnable()
    {
        EventManager.OnBoulderFall += PlayHitSound;
        EventManager.OnPlayerHit += PlayerDie;
    }

    void OnDisable()
    {
        EventManager.OnBoulderFall -= PlayHitSound;
        EventManager.OnPlayerHit -= PlayerDie;
    }

    void PlayHitSound()
    {

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); 
        }
    }

    void PlayerDie()
    {
        gameOverManager.TriggerDefeat();
    }
}
