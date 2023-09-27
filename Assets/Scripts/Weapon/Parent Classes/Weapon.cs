using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private float knocbackModifier, atkModifier, atkSpdModifier;
    [SerializeField]
    private GameObject weaponCollider;
    [SerializeField]
    private bool isMelee;

    private ContactFilter2D contactFilter;

    public float KnocbackModifier { get => knocbackModifier; set => knocbackModifier = value; }
    public float AtkModifier { get => atkModifier; set => atkModifier = value; }
    public float AtkSpdModifier { get => atkSpdModifier; set => atkSpdModifier = value; }
    public bool IsMelee { get => isMelee; set => isMelee = value; }
    public GameObject AttackCollider { get => weaponCollider; set => weaponCollider = value; }

    private void Start()
    {
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.NameToLayer("Enemy"));
    }

    //public List<Collider2D> GetEnemyCollider() 
    //{
        

    //    //Physics2D.OverlapCollider(attackCollider, contactFilter, enemyColliders);

    //    Debug.Log("enemyColliders returned");
    //    return weaponCollider.GetComponent<WeaponCollider>().EnemyColliders;
    //}

    public void ApplyDamage(List<Collider2D> enemyColliders, float atkPoint) 
    {
        for (int i = 0; i < enemyColliders.Count; i++)
        {
            if (enemyColliders[i] != null && enemyColliders[i].isTrigger == true)
            { 
            enemyColliders[i].gameObject.transform.parent.GetComponent<MeleeAI>().Hp -= (atkModifier * atkPoint);
            Debug.Log("Applied Damage");
            }
        }
    
    }

    public void ApplyKnockback(List<Collider2D> enemyColliders) 
    {
 
        //deals knockback from the transform pos
        //
        Transform posCache;

        Debug.Log(enemyColliders.Count);

        for (int i = 0; i < enemyColliders.Count; i++)
        {
            if (enemyColliders[i]!= null && enemyColliders[i].isTrigger == true)
            {
                Debug.Log("Rigidbody2D assigned");
                Rigidbody2D rbEnemy = enemyColliders[i].gameObject.transform.parent.GetComponent<Rigidbody2D>();

                if (rbEnemy != null)
                {

                    enemyColliders[i].gameObject.transform.parent.GetComponent<MeleeAI>().IsStunned = true;


                    posCache = rbEnemy.transform;

                    Vector2 toEnemyDir = posCache.position - transform.position;


                    //Debug.Log(knockbackDistance);

                    rbEnemy.velocity = Vector2.zero;
                    //rb.AddForce(toEnemyDir.normalized * explosionStrength, ForceMode2D.Impulse);
                    rbEnemy.AddForce(knocbackModifier * toEnemyDir.normalized, ForceMode2D.Impulse);
                    Debug.Log("Added Knockback");



                }
            }
        }


    }

}
