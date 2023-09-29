using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    [SerializeField] int currentLevel;
    [SerializeField] GameObject levelChecker;
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (levelChecker.gameObject.GetComponent<CheckCleared>().LevelCleared == true)
            {
                if (currentLevel == 1)
                    SceneManager.LoadScene("level2", LoadSceneMode.Single);
                else if (currentLevel == 2)
                    SceneManager.LoadScene("level3", LoadSceneMode.Single);
                else if (currentLevel == 3)
                    SceneManager.LoadScene("End Story");


            }
        }

    }
}
