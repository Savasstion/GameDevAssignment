using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : Enemy
{
    [SerializeField] Rigidbody2D projectile;
    [SerializeField] LayerMask playerLayerMask, obstaclesLayerMask; //obstaclesLayerMask should be both player and obstacles
    [SerializeField] Transform gunBarrel;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] float detectionRange, projectileSpeed = 1;
    [SerializeField] float atkCooldown = 3f;
    [SerializeField] float fireRate = 1f / 15f;
    private bool allowedToFire = true;

    IEnumerator FireBurst() 
    {
        allowedToFire = false;
        for (int i = 0; i < 15; i++)
        {
            Attack(playerCollider.transform.position - transform.position);
            yield return new WaitForSeconds(fireRate); // 15 shots per second
        }
        yield return new WaitForSeconds(atkCooldown);
        allowedToFire = true;
    }

    public override void Attack(Vector2 aimDir)
    {
        Rigidbody2D projectileInstance;
        projectileInstance = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;
        projectileInstance.velocity = aimDir.normalized * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayerCollider();


        if (allowedToFire)
        {
            StartCoroutine(FireBurst());

        }

        if (Attacking)
        {
            Timer += Time.deltaTime;

            if (Timer >= TimeToAttack)
            {
                Timer = 0;
                Attacking = false;
                AttackArea.SetActive(Attacking);
            }

        }
    }
    void DetectPlayerCollider()
    {
        Transform playerTransform = null;
        List<Collider2D> colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange).ToList();

        for (int i = 0; i < colliders.Count; i++)
        {
            if ((1 << (colliders[i].gameObject.layer) & playerLayerMask) != 0)
            {
                playerTransform = colliders[i].transform;
                break;
            }
        }

        if (playerTransform == null)
            return;

        Vector2 directionToPlayer = new Vector2(playerTransform.position.x - transform.position.x, playerTransform.position.y - transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, obstaclesLayerMask);

        if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
            playerCollider = hit.collider;
        else
            playerCollider = null;

    }


    public override void AlertAllEnemies()
    {
        throw new System.NotImplementedException();
    }

   

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateQuest()
    {
        throw new System.NotImplementedException();
    }
}
