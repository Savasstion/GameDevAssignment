using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBullet : Bullet
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null
            && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.Damage(Damage);
            Debug.Log("Damage Dealt");
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(this.gameObject);
        }
        
            
    }
}
