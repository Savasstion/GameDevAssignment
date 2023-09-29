using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject youLosePanel; 
    public string playerTag = "Player"; 

    private void Start()
    {
        youLosePanel.SetActive(false);
    }

    private void Update()
    {
     
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        if (players.Length == 0)
        {
            ShowYouLosePanel();
        }
    }

    private void ShowYouLosePanel()
    {

        youLosePanel.SetActive(true);

        Time.timeScale = 0f;
    }

   
}
