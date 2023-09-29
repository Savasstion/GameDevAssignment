using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void ResumeGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    //}

    //public void RestartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    //}
    public void Setting()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void BackTMMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }


    public void Quit()
    {
        SceneManager.LoadScene("ComfirmQuit");
        
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

}
