using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSkill : PlacementSkill
{
    [SerializeField]
    private Rigidbody2D rb;




    public override void castSkill()
    {
        Collider2D[] enemyCollider = getEnemyCollider();
        for (int i = 0; i < enemyCollider.Length; i++) 
        {
            rb = enemyCollider[i].GetComponent<Rigidbody2D>();
            Vector2 toEnemyDir = rb.transform.position - transform.position;
            float distance = toEnemyDir.magnitude;

            float knockbackDistance = SkillRadius - distance;

            rb.AddForce(toEnemyDir.normalized * knockbackDistance, ForceMode2D.Impulse);

        }
        

    }
}
