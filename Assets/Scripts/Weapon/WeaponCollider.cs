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
        if((enemyLayerMask.value & (1 << other.gameObject.layer)) != 0 && other.isTrigger == true)
            enemyColliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if ((enemyLayerMask.value & (1 << other.gameObject.layer)) != 0 && other.isTrigger == true)
            enemyColliders.Remove(other);
    }

}
