using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    [SerializeField]
    private List<Collider2D> enemyColliders;
    [SerializeField]
    private LayerMask enemyLayerMask;
    public List<Collider2D> EnemyColliders { get => enemyColliders; set => enemyColliders = value; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enemyLayerMask = " + enemyLayerMask.value);
        Debug.Log("otherLayerMask = " + (1 << ((1 << other.gameObject.layer) - 1)));

        if (enemyLayerMask.value == (1 << ((1 << other.gameObject.layer) - 1)))  /*&& other.isTrigger == true*/
            enemyColliders.Add(other);
        else
            Debug.Log("Failed to add Collider");
    }

    //private void OnTriggerExit2D(Collider2D other) 
    //{
    //    if (enemyLayerMask.value == (1 << ((1 << other.gameObject.layer) - 1))) /*&& other.isTrigger == true*/
    //        enemyColliders.Remove(other);
    //    else
    //        Debug.Log("Failed to remove Collider");
    //}

}
