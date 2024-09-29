using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObject : ICommand
{
    private GameObject currentCameraGO;
    //private GameObject objectToFocus;
    private GameObject player;
    private GameObject timeCoinCamera;
    private RectTransform topImage;
    private RectTransform bottomImage;

    private float moveSpeed = 50;
    private float distance = 200;

    public FocusObject(GameObject _currentCameraGO, GameObject _player, GameObject _timeCoinCamera, RectTransform _topImage, RectTransform _bottomImage)
    {
        currentCameraGO = _currentCameraGO;
        //objectToFocus = _objectToFocus;
        player = _player;
        timeCoinCamera = _timeCoinCamera;
        topImage = _topImage;
        bottomImage = _bottomImage;
    }

    public void Do()
    {
        currentCameraGO.SetActive(false);
        player.GetComponent<CharacterInput>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        timeCoinCamera.SetActive(true);
        //StartCoroutine(FocusUI());        
    }

    public void Undo()
    {
        currentCameraGO.SetActive(true);
        player.GetComponent<CharacterInput>().enabled = true;
        player.GetComponent<CharacterInput>().movementLogic = player.GetComponent<CharacterInput>().characterWalk;
        player.GetComponent<AudioSource>().enabled = true;
        timeCoinCamera.SetActive(false);
        //StartCoroutine(UnfocusUI());
    }

    private IEnumerator FocusUI()
    {
        bool finished = false;
        float aux = bottomImage.anchoredPosition.y;
        while(!finished)
        {
            topImage.anchoredPosition += new Vector2(0, -moveSpeed * Time.deltaTime);
            bottomImage.anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            if((aux + distance) > topImage.anchoredPosition.y)
            {
                finished = true;
            }
            yield return null;
        }
    }

    private IEnumerator UnfocusUI()
    {
        bool finished = false;
        float aux = bottomImage.anchoredPosition.y; // -450
        while(!finished)
        {
            topImage.anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            bottomImage.anchoredPosition += new Vector2(0, -moveSpeed * Time.deltaTime);
            if(aux < topImage.anchoredPosition.y)
            {
                finished = true;
            }
            yield return null;
        }
    }

}
