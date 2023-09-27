using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeSkill : PlacementSkill
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float explosionStrength = 10f;
    [SerializeField]
    private bool showGizmos = false;



    public override void CastSkill()
    {
        //deals knockback from the transform pos
        //
        Collider2D[] enemyCollider = getEnemyCollider();
        Transform posCache;

        Debug.Log(enemyCollider.Length);

        for (int i = 0; i < enemyCollider.Length; i++) 
        {
            rb = enemyCollider[i].attachedRigidbody;

            if (rb != null)
            {
                
                enemyCollider[i].gameObject.GetComponent<MeleeAI>().IsStunned = true;


                posCache = rb.transform;

                Vector2 toEnemyDir = posCache.position - SkillPos.position;


                //Debug.Log(knockbackDistance);

                rb.velocity = Vector2.zero;
                //rb.AddForce(toEnemyDir.normalized * explosionStrength, ForceMode2D.Impulse);
                rb.AddForce((SkillRadius - toEnemyDir.magnitude) * explosionStrength * toEnemyDir.normalized, ForceMode2D.Impulse);


                Debug.Log((SkillRadius - toEnemyDir.magnitude));
            }
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(SkillPos.position, SkillRadius);

    }
}