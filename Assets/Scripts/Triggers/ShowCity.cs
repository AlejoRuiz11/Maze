using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCity : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject TMPinfoGO;
    [SerializeField] private string info;
    //
    [SerializeField] private GameObject objectCamera;
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private GameObject topImageGO;
    [SerializeField] private GameObject bottomImageGO;

    private GameObject cameraa;
    public bool used = false;
    
    private float moveDistance = 200f;
    private float moveSpeed = 105f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FocusCity());
    }

    private IEnumerator FocusCity()
    {
        if(firstPersonCamera.activeInHierarchy) cameraa = firstPersonCamera;
        else cameraa = thirdPersonCamera;

        FocusObject focusTimeCoin = new FocusObject(cameraa, player, objectCamera);
        focusTimeCoin.Do();
        
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
    }
}
