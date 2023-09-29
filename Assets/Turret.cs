using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : Enemy
{
    //[SerializeField] Transform playerTransform;
    [SerializeField] GameObject projectile;
    [SerializeField] LayerMask playerLayerMask, obstaclesLayerMask; //obstaclesLayerMask should be both player and obstacles
    [SerializeField] Transform gunBarrel;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] float detectionRange, projectileSpeed = 1;
    [SerializeField] float atkCooldown = 3f;
    [SerializeField] float fireRate = 1f / 5f;
    [SerializeField] float burstAmount = 5;
    [SerializeField] AudioSource lazerBeamAudio;
    private bool inCoolDown;
    private Vector2 aimDir;
    IEnumerator ShootBurst()
    {
        inCoolDown = true;
        Vector3 Position = new Vector3(transform.position.x,
                                       transform.position.y + .169f,
                                       0);
        for (int i = 0; i < burstAmount; i++)
        {
            var projectileInstance = Instantiate(projectile,
                        Position,
                        Quaternion.identity);
            aimDir = new Vector2(playerCollider.transform.position.x - transform.position.x, playerCollider.transform.position.y - transform.position.y);
            projectileInstance.gameObject.GetComponent<Rigidbody2D>().velocity = aimDir.normalized * projectileSpeed;
            lazerBeamAudio.Play();
            yield return new WaitForSeconds(fireRate);
        }
        yield return new WaitForSeconds(Random.Range(atkCooldown - .5f, atkCooldown + .5f));
        inCoolDown = false;
    }

    private void Update()
    {
        if(aimDir.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    private void Start()
    {
        inCoolDown = false;
        IsStunned = false;
        //InvokeRepeating(nameof(DetectPlayerCollider), 0, 0);
       
    }
    public override void Attack(Vector2 aimDir)
    {
 
        var projectileInstance = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation);
        projectileInstance.gameObject.GetComponent<Rigidbody2D>().velocity = (aimDir.normalized * projectileSpeed );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!CheckIfDefeated())
        {
            if (IsStunned)
            {

                Invoke(nameof(UnStunned), 0.5f);
                return;
            }


            if (inCoolDown == false && playerCollider != null && !IsStunned)
            {
                
                inCoolDown = true;
                StartCoroutine(ShootBurst());
            }
        }
    }
    //void DetectPlayerCollider()
    //{
    //    //Transform playerTransform = null;
    //    //List<Collider2D> colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange).ToList();

    //    //for (int i = 0; i < colliders.Count; i++)
    //    //{
    //    //    if ((1 << (colliders[i].gameObject.layer) & playerLayerMask) != 0)
    //    //    {
    //    //        playerTransform = colliders[i].transform;
    //    //        break;
    //    //    }
    //    //}

    //    if (playerTransform == null)
    //        return;

    //    Vector2 directionToPlayer = new Vector2(playerTransform.position.x - transform.position.x, playerTransform.position.y - transform.position.y);
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, obstaclesLayerMask);

    //    if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
    //        playerCollider = hit.collider;
    //    else
    //        playerCollider = null;

    //}


    public override void AlertAllEnemies()
    {

    }

   

    public override void Move()
    {

    }

    public override void UpdateQuest()
    {

    }
}
