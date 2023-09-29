using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSelected : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
    public void Setting()
    {
        SceneManager.LoadScene("Setting Menu");
    }

    public void Guide()
    {
        SceneManager.LoadScene("Guide");
    }


    public void Quit()
    {
        SceneManager.LoadScene("ComfirmQuit");
        
    }

}
