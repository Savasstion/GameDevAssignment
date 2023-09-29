using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject youWinPanel; 
    public string enemyTag = "Enemy"; 
    public string keyTag = "Key";

    private void Start()
    {
     
        youWinPanel.SetActive(false);
    }

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] keys = GameObject.FindGameObjectsWithTag(keyTag);

        if (enemies.Length == 0 && keys.Length == 0)
        {
            ShowYouWinPanel();
        }
    }

    private void ShowYouWinPanel()
    {
        
        youWinPanel.SetActive(true);
    }
}
