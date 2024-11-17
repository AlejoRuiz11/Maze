using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject loadingScreenPanel;
    public Slider loadingSlider;

    public void PlayGame()
    {

        StartCoroutine(LoadSceneWithProgress("GameScene"));
    }

    private IEnumerator LoadSceneWithProgress(string sceneName)
    {

        loadingScreenPanel.SetActive(true);

        loadingSlider.value = 0;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;

            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        loadingScreenPanel.SetActive(false);
    }
}