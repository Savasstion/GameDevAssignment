using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    //[SerializeField]
    //private GameObject levelChecker;

    //private void Start()
    //{
    //    StartCoroutine(firstTimeWait());
        
    //}

    public abstract void AlertAllEnemies();

    //IEnumerator firstTimeWait()
    //{

    //    yield return new WaitForSeconds(1f);
    //    levelChecker.GetComponent<CheckCleared>().TotalEnemies += 1;
    //}
}
