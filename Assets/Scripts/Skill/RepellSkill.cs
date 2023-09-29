using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepellSkill : PlacementSkill
{
    Rigidbody2D rb;
    [SerializeField]
    float repellStrength = 500f;
    




    public override void CastSkill()
    {
        Collider2D[] enemyCollider = getEnemyCollider();
        Transform posCache;

        Debug.Log(enemyCollider.Length);



        for (int i = 0; i < enemyCollider.Length; i++)
        {
            rb = enemyCollider[i].gameObject.GetComponent<Actor>().Rb;

            if (rb != null)
            {
                //knockback
                enemyCollider[i].gameObject.GetComponent<Actor>().IsStunned = true;


                posCache = rb.transform;

                Vector2 toEnemyDir = posCache.position - SkillPos.position;


                //Debug.Log(knockbackDistance);

                rb.velocity = Vector2.zero;
                //rb.AddForce(toEnemyDir.normalized * explosionStrength, ForceMode2D.Impulse);
                rb.AddForce((SkillRadius - toEnemyDir.magnitude) * repellStrength * toEnemyDir.normalized, ForceMode2D.Impulse);
                Debug.Log("Dealt Knockback");

                //Debug.Log((SkillRadius - toEnemyDir.magnitude));

               
            }
        }

       
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(SkillPos.position, SkillRadius);

    }
}

   

