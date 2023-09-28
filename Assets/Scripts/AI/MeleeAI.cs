using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    float atkCooldown;
    [SerializeField]
    float atkRange;

    [SerializeField]
    private float detectionDelay = 0.05f;

    [SerializeField]
    private ContextSolver movementDirectionSolver;

    private Collider2D playerCollider;
    [SerializeField]
    private LayerMask playerLayerMask, obstaclesLayerMask;
    [SerializeField]
    private float dashToPlayerDistance = 2f;

    //public float minDistanceToAttack = .5f;
    private bool isAllowedDodge;
    public float dodgeCooldown;
    public Transform player;
    private bool allowedToAttack;

    public float AtkRange { get => atkRange; set => atkRange = value; }
    public bool AllowedToAttack { get => allowedToAttack; set => allowedToAttack = value; }
    public float AtkCooldown { get => atkCooldown; set => atkCooldown = value; }

    IEnumerator AllowAttack()
    {
        yield return new WaitForSeconds(AtkCooldown);
        allowedToAttack = true;
        Debug.Log("Set Allow Attack True");
        //CancelInvoke(nameof(AllowAttack));
    }


    //IEnumerator AllowAttack()
    //{
    //    yield return new WaitForSeconds(atkCooldown);
    //    allowedToAttack = true;
    //    Debug.Log("Set Allow Attack True");
    //}


    private void Update()
    {
        

           
        if (!CheckIfDefeated())
        { 
            Move();

            if ((player.position - transform.position).magnitude <= (atkRange) 
                && !isAllowedDodge
                && allowedToAttack)
            {
                //StartCoroutine(TelegraphThenAttack());
                allowedToAttack = false;
                Attack((player.position - transform.position).normalized);


            }
            if (Attacking)
            {
                Timer += Time.deltaTime;
                allowedToAttack = false;
                if (Timer >= TimeToAttack)
                {

                    Timer = 0;
                    Attacking = false;
                    AttackArea.SetActive(Attacking);
                    allowedToAttack = false;
                    
                }

            }
            StartCoroutine(nameof(AllowAttack));

        }


        //if (Hp <= 0)
        //{
        //    //set defeated bool true in animator
        //    EnterDefeatState();
        //}


    }



    private void Start()
    {
        allowedToAttack = true;
        isAllowedDodge = true;
        IsStunned = false;
        InvokeRepeating(nameof(PerformDetection), 0, detectionDelay);

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

            Invoke(nameof(UnStunned), 0.5f);
            return;
        }



        if (MoveDir.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;


        //if (!IsInvulnerable)
        //{
        //  Attack(MoveDir);
        // }
        if (isAllowedDodge && allowedToAttack)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, dashToPlayerDistance, playerLayerMask);
            if (playerCollider != null /*&& (playerCollider.transform.position - transform.position).magnitude >= minDistanceToAttack*/)
            {

                Vector2 directionToPlayer = (playerCollider.transform.position - transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer
                    , dashToPlayerDistance, obstaclesLayerMask);

                if ((hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0))
                {
                    //Debug.Log("Dash");

                    StartCoroutine(DashFeedback());
                    Dash(directionToPlayer);

                    

                    IsInvulnerable = false;
                    isAllowedDodge = false;
                    Invoke(nameof(AllowDodge), Random.Range(dodgeCooldown - 1.2f, dodgeCooldown + 1.2f));



                    return;
                }
                //else
                //Debug.Log("No Dash");
            }
        }
        allowedToAttack = false;
        MoveDir = Rb.velocity = movementDirectionSolver.GetDirToMove(steeringBehaviours, aiData) * MoveSpeed;
        //Debug.Log("Moved");
    }

    //IEnumerator AllowDodge() 
    //{
    //    yield return new WaitForSeconds(Random.Range(dodgeCooldown - 1.2f, dodgeCooldown + 1.2f));
    //    isAllowedDodge = true;
    //    Debug.Log("Set Allow Dodge True");
    //}

    void AllowDodge()
    {
        isAllowedDodge = true;
        Debug.Log("Set Allow Dodge True");
    }

    

    IEnumerator DashFeedback() 
    {
    this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void Attack(Vector2 attackDr)
    {

        Animator.SetTrigger("Attack");

        Debug.Log("Attack Anim triggered");

        //List<Collider2D> enemyColliders = equippedWeapon.GetEnemyCollider(equippedWeapon.AttackCollider);


        Debug.Log("Enemy Attacking");
        Attacking = true;

        AttackArea.SetActive(Attacking);

    }

    //IEnumerator TelegraphThenAttack()
    //{
    //    this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    //    yield return new WaitForSeconds(.2f);
    //    this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    //    //Attack((player.position - transform.position).normalized);


    //}

    public override void AlertAllEnemies()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateQuest()
    {
        throw new System.NotImplementedException();
    }
}
