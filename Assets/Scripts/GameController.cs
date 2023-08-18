using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI successText;
    public int score = 0;
    public int gemCollected;
    public int maxGemCount;
    //string successMessage = "Well Done!";

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScore(int gemValue)
    {
        score += gemValue;
        gemCollected++;
        text.text = score.ToString();

        if(gemCollected >= maxGemCount)
        successText.text = "Well Done!".ToString();


    }


}
