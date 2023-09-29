using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastSceneInput : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            Application.Quit();
        else if (Input.GetKeyUp(KeyCode.F))
            SceneManager.LoadScene("level 1");
    }
}
