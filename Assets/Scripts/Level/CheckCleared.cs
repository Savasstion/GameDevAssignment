using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCleared : MonoBehaviour
{
    [SerializeField] int totalEnemies = 0;
    [SerializeField] int enemiesCleared;
    [SerializeField] bool levelCleared;
    [SerializeField] GameObject exit;

    public int TotalEnemies { get => totalEnemies; set => totalEnemies = value; }
    public int EnemiesCleared { get => enemiesCleared; set => enemiesCleared = value; }
    public bool LevelCleared { get => levelCleared; set => levelCleared = value; }

    private void Start()
    {
        EnemiesCleared = 0;
        //StartCoroutine(firstTimeWait());
        LevelCleared = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();


        if (enemiesCleared >= totalEnemies)
            levelCleared = true;
        else
            levelCleared = false;

        if (levelCleared)
            exit.SetActive(true);
        else 
            exit.SetActive(false);
    }

    //IEnumerator firstTimeWait() 
    //{
    //    enemiesCleared++;
    //    yield return new WaitForSeconds(.1f);
    //    enemiesCleared--;
    //}

}
