using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    public float displayTime = 3f; 

    private void Start()
    {
 
        subtitleText.gameObject.SetActive(false);

        StartCoroutine(ShowSubtitle());
    }

    IEnumerator ShowSubtitle()
    {
        
        subtitleText.gameObject.SetActive(true);


        yield return new WaitForSeconds(displayTime);

     
        subtitleText.gameObject.SetActive(false);
    }
}
