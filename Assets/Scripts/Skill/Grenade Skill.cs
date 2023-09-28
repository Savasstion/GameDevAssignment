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

    private int amountExploded = 0;
    public GameObject explosions;

    private void Update()
    {




    }

    public override void CastSkill()
    {
        //deals knockback from the transform pos
        //

        if (amountExploded == 3)
            amountExploded = 0;
        Collider2D[] enemyCollider = getEnemyCollider();
        Transform posCache;

        Debug.Log(enemyCollider.Length);

        explosions.transform.GetChild(amountExploded).transform.position = SkillPos.position;

        StartCoroutine(triggerExploion());
        amountExploded++;
        for (int i = 0; i < enemyCollider.Length; i++)
        {
            rb = enemyCollider[i].attachedRigidbody;

            if (rb != null)
            {
                //knockback
                enemyCollider[i].gameObject.GetComponent<Actor>().IsStunned = true;


                posCache = rb.transform;

                Vector2 toEnemyDir = posCache.position - SkillPos.position;


                //Debug.Log(knockbackDistance);

                rb.velocity = Vector2.zero;
                //rb.AddForce(toEnemyDir.normalized * explosionStrength, ForceMode2D.Impulse);
                rb.AddForce((SkillRadius - toEnemyDir.magnitude) * explosionStrength * toEnemyDir.normalized, ForceMode2D.Impulse);


                //Debug.Log((SkillRadius - toEnemyDir.magnitude));

                //damage
                if (enemyCollider[i].gameObject.GetComponent<Health>() != null
            && enemyCollider[i].gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Health health = enemyCollider[i].gameObject.GetComponent<Health>();
                    health.Damage(explosionStrength / 2);
                    Debug.Log("Damage Dealt");
                }
                else
                    Debug.Log("Failed to deal damage");
            }
        }

        IEnumerator triggerExploion()
        {
            explosions.transform.GetChild(amountExploded).gameObject.SetActive(true);

            int buffer = amountExploded;
            yield return new WaitForSeconds(.5f);
            explosions.transform.GetChild(buffer).gameObject.SetActive(false);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(SkillPos.position, SkillRadius);

    }
}