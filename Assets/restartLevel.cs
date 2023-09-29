using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour
{
    [SerializeField] string currentLevel;

    public void Restart() { 
    StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(currentLevel); ;

    }
}
