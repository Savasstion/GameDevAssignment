using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class RangeAI : Enemy
{
    [SerializeField] float detectionRange;
    [SerializeField] float runAwayThreshold;

    //obstaclesLayerMask put both Obstacle and Player layer
    [SerializeField]  LayerMask obstaclesLayerMask, playerLayerMask, enemyLayerMask;
    [SerializeField] float unitsToHideBehindEnemy;
    [SerializeField] Vector2 playerDir;
    Collider2D playerCollider;
    Transform closestAllyTransform;

    void Start()
    {
        InvokeRepeating(nameof(DetectPlayerCollider), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerDir.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;


        if (!CheckIfDefeated())
        {
            if (IsStunned)
            {

                Invoke(nameof(UnStunned), 0.5f);
                return;
            }

            if (playerCollider != null && !IsStunned)
            {
                playerDir = (playerCollider.transform.position - transform.position);


                //movement
                if (playerDir.magnitude <= runAwayThreshold)
                {
                    Rb.velocity = Vector2.zero;
                    closestAllyTransform = DetectAllies();
                    if (closestAllyTransform != null)
                    {
                        MoveToDir(new Vector2((closestAllyTransform.position.x - playerCollider.transform.position.x),
                            (closestAllyTransform.position.y - playerCollider.transform.position.y)));
                    }
                    else
                        MoveToDir(GetAwayFromPlayerDir(playerCollider));
                }
            }
        }
    }

    void MoveToDir(Vector2 dir)
    {
        Rb.velocity = dir.normalized * MoveSpeed;
    }

    //void GoToPoint(Vector2 point) 
    //{
    //    if (new Vector2(transform.position.x, transform.position.y) != new Vector2(point.x, point.y))
    //        Rb.velocity = (new Vector2(point.x, point.y) - new Vector2(transform.position.x, transform.position.y)).normalized * MoveSpeed;
    //}

    //Vector2 GetBehindAllyPoint(Collider2D playerCollider, Transform closestAllyTransform) 
    //{
    //    return new Vector2(closestAllyTransform.position.x - playerCollider.transform.position.x, 
    //        closestAllyTransform.position.y - playerCollider.transform.position.y).normalized * unitsToHideBehindEnemy;
    //}

    Vector2 GetAwayFromPlayerDir(Collider2D playerCollider) 
    {
        return new Vector2(transform.position.x - playerCollider.transform.position.x, transform.position.y - playerCollider.transform.position.y).normalized;


    }

    Transform DetectAllies() 
    {
        List<Collider2D> colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange).ToList();

        if (colliders != null)
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                if ((1 << (colliders[i].gameObject.layer) & enemyLayerMask) == 0)
                {
                    colliders.Remove(colliders[i]);
                }
            }

            float closestDistance = new Vector2(colliders[0].transform.position.x - transform.position.x, colliders[0].transform.position.y - transform.position.y).magnitude;
            float currentIndexDistance;
            int indexOfClosest = 0;

            for (int i = 1; i < colliders.Count; i++)
            {
                currentIndexDistance = new Vector2(colliders[i].transform.position.x - transform.position.x, colliders[i].transform.position.y - transform.position.y).magnitude;

                if (currentIndexDistance < closestDistance)
                {
                    closestDistance = currentIndexDistance;
                    indexOfClosest = i;
                }
            }
            Debug.Log("Enemy succeeded in detecting their allies");
            return colliders[indexOfClosest].transform;
        }
        else
        {
            Debug.Log("Enemy failed to detect their allies");
            return null;
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

    public override void Attack(Vector2 aimDir)
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
