using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private float damage = 35;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OnTrigger");
        if (collider.gameObject.GetComponent<Health>() != null
            && collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) 
        {
            Health health = collider.gameObject.GetComponent<Health>();
            health.Damage(damage);
            Debug.Log("Damage Dealt");
        }else
            Debug.Log("Failed to deal damage");
    }
}
