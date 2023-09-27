using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{

    public Sprite On;
    public Sprite Off;
    public Button button;
    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        On = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = Off;
            isOn = false;
            Screen.fullScreen = !Screen.fullScreen;

        }
        else
        {
            button.image.sprite = On;
            isOn = true;
            Screen.fullScreen = !Screen.fullScreen;
        }

    }


}
