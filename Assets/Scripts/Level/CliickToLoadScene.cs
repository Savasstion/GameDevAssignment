using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoadScene : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene you want to load


    // Update is called once per frame
    void Update()
    {
        // Check for mouse click (left mouse button)
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
                SceneManager.LoadScene(sceneToLoad);
            
        }
    }
}