using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerFocus : MonoBehaviour
{
    private bool done = false;
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private GameObject thirdPersonCamera;
    //[SerializeField] private GameObject timeCoin;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject TimeCoinCamera;
    
    // UI Focus
    [SerializeField] private GameObject topImageGO;
    [SerializeField] private GameObject bottomImageGO;
    [SerializeField] private GameObject TMPinfoGO;
    [SerializeField] private string info;
    [SerializeField] GameObject minimapUI;
    
    private float moveDistance = 200f;
    private float moveSpeed = 105f;

    private void OnTriggerEnter(Collider collider) {
        if(!done)
        {
            IMovable movable = collider.GetComponent<IMovable>();
            if(movable!=null)
            {
                if(firstPersonCamera.activeInHierarchy)
                {
                    StartCoroutine(callCommand(firstPersonCamera));
                }
                else
                {
                    StartCoroutine(callCommand(thirdPersonCamera));
                }
            }
        }
        
    }

    private IEnumerator callCommand(GameObject camera)
    {
        done = true;
        FocusObject focusTimeCoin = new FocusObject(camera, player, TimeCoinCamera);
        focusTimeCoin.Do();
        
        minimapUI.SetActive(false);
        RectTransform topImage = topImageGO.GetComponent<RectTransform>();
        RectTransform bottomImage = bottomImageGO.GetComponent<RectTransform>();
        float aux = bottomImage.anchoredPosition.y; // -650
        bool finished = false;
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

        TMPinfoGO.SetActive(true);
        TextMeshProUGUI TMPinfo = TMPinfoGO.GetComponent<TextMeshProUGUI>();
        TMPinfo.text = info;

        yield return new WaitForSeconds(6);
        focusTimeCoin.Undo();
        float aux2 = bottomImage.anchoredPosition.y; // -650
        finished = false;
        aux = bottomImage.anchoredPosition.y;
        TMPinfoGO.SetActive(false);
        while(!finished)
        {
            topImage.anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            bottomImage.anchoredPosition += new Vector2(0, -moveSpeed * Time.deltaTime);
            if((aux2 - 200) > bottomImage.anchoredPosition.y)
            {
                finished = true;
            }
            yield return null;
        }
        minimapUI.SetActive(true);

        //topImage.anchoredPosition = topImageBackup.anchoredPosition;
        //bottomImage.anchoredPosition = bottomImageBackup.anchoredPosition;

    }

}
