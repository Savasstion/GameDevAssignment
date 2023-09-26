using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MeleeAI : Enemy
{
    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private List<SteeringBehaviour> steeringBehaviours;

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, speed;

    [SerializeField]
    private ContextSolver movementDirectionSolver;

    private Collider2D playerCollider;
    [SerializeField]
    private LayerMask playerLayerMask, obstaclesLayerMask;
    [SerializeField]
    private float dashToPlayerDistance = 2;

    private bool isAllowedDodge;
    public float dodgeCooldown;



    private void Update()
    {

        if (IsInvulnerable)
        {
            Invoke("BecomeVulnerable", 0.5f);
            return;
        }

        if (Hp <= 0)
        {
            //set defeated bool true in animator
            EnterDefeatState();
        }


    }



    private void Start()
    {
        isAllowedDodge = true;
        IsStunned = false;
        InvokeRepeating("PerformDetection", 0, detectionDelay);

    }

    private void FixedUpdate()
    {
        //rb2d.velocity = Vector2.zero;

        Move();

       

    }

    private void PerformDetection() 
    {
        for(int i = 0; i < detectors.Count; i++) 
        {
            detectors[i].Detect(aiData);
        }

        
    }

    public override void Move()
    {
        if (IsStunned)
        {

            Invoke("UnStunned", 0.5f);
            return;
        }


        //if (!IsInvulnerable)
        //{
        //  Attack(MoveDir);
        // }
        if (isAllowedDodge)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, dashToPlayerDistance, playerLayerMask);
            if (playerCollider != null)
            {

                Vector2 directionToPlayer = (playerCollider.transform.position - transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer
                    , dashToPlayerDistance, obstaclesLayerMask);

                if ((hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0))
                {
                    //Debug.Log("Dash");

                    Dash(directionToPlayer);
                    IsInvulnerable = false;
                    isAllowedDodge = false;
                    StartCoroutine("AllowDodge");
                    return;
                }
                //else
                //Debug.Log("No Dash");
            }
        }
        MoveDir = Rb.velocity = movementDirectionSolver.GetDirToMove(steeringBehaviours, aiData) * speed;
        //Debug.Log("Moved");
    }

    IEnumerator AllowDodge() 
    {
        yield return new WaitForSeconds(dodgeCooldown);
        isAllowedDodge = true;
        Debug.Log("Set Allow Dodge True");
    }

    public override void Attack(Vector2 attackDr)
    {
        throw new System.NotImplementedException();
    }

    public override void AlertAllEnemies()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateQuest()
    {
        throw new System.NotImplementedException();
    }
}
