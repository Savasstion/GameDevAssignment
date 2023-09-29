using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeSkill : PlacementSkill
{
    [SerializeField] GameObject grenade;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float explosionStrength = 10f;
    [SerializeField]
    private bool showGizmos = false;
    private Vector2 contactPoint;

    private int amountExploded = 0;
    public GameObject explosions;
    public AudioSource explosionAudio;

    IEnumerator ExplodeAfterDelay()
    {

        yield return new WaitForSeconds(SkillCastDelayTime);
        Explode();


    }

    IEnumerator SpawnGrenade()
    {

        Vector3 Position = new Vector3(transform.position.x,
                                       transform.position.y,
                                       0);


        var projectileInstance = Instantiate(grenade,
                    Position,
                    Quaternion.identity);
        Vector2 aimDir = new Vector2(contactPoint.x - transform.position.x, contactPoint.y - transform.position.y);

        //who knew those secondary school physics formula is actually useful
        // velocity = displacement / time;
        float speed = aimDir.magnitude / SkillCastDelayTime;


        projectileInstance.gameObject.GetComponent<Rigidbody2D>().velocity = aimDir.normalized * speed;


        yield return new WaitForSeconds(SkillCastDelayTime);

        Destroy(projectileInstance.gameObject);

    }


    public void Explode()
    {
        //deals knockback from the transform pos
        //

        if (amountExploded == 3)
            amountExploded = 0;
        Collider2D[] enemyCollider = getEnemyCollider(contactPoint);
        Transform posCache;

        Debug.Log(enemyCollider.Length);

        explosions.transform.GetChild(amountExploded).transform.position = contactPoint;

        StartCoroutine(triggerExploion());
        amountExploded++;
        for (int i = 0; i < enemyCollider.Length; i++)
        {
            rb = enemyCollider[i].gameObject.GetComponent<Actor>().Rb;

            if (rb != null)
            {
                //knockback
                enemyCollider[i].gameObject.GetComponent<Actor>().IsStunned = true;


                posCache = rb.transform;

                Vector2 toEnemyDir = (Vector2)posCache.position - contactPoint;


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
            explosionAudio.Play();
            int buffer = amountExploded;
            yield return new WaitForSeconds(.5f);
            explosions.transform.GetChild(buffer).gameObject.SetActive(false);
        }

    }
    public override void CastSkill()
    {
        contactPoint = (Vector2)SkillPos.position;
        StartCoroutine(SpawnGrenade());
        StartCoroutine(ExplodeAfterDelay());
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(contactPoint, SkillRadius);

    }
}