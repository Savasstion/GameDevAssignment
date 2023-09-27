using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : Actor
{
    [SerializeField]
    private Weapon equippedWeapon;
    [SerializeField]
    private bool isInCombat;
    [SerializeField]
    private bool isInMenu;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private Transform lastChkPointCoord;
    [SerializeField]
    private float defModifier;
    [SerializeField]
    private bool isAllowedDodge;
    [SerializeField]
    private Vector2 aimDir;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private short dashCount = 0, maxDashCount;
    [SerializeField]
    private float dashCoolDownTime;

    public AudioSource audioSource;
    public Transform mousePos;

    private bool faceRight = true;

    public bool IsInCombat { get => isInCombat; set => isInCombat = value; }
    public bool IsInMenu { get => isInMenu; set => isInMenu = value; }
    public int MaxHP { get => maxHP; set => maxHP = value; }
    public Transform LastChkPointCoord { get => lastChkPointCoord; set => lastChkPointCoord = value; }
    public float DefModifier { get => defModifier; set => defModifier = value; }
    public bool IsAllowedDodge { get => isAllowedDodge; set => isAllowedDodge = value; }
    public Vector2 AimDir { get => aimDir; set => aimDir = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public Weapon EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }

    void Start() 
    {
        IsInvulnerable = false;
        //audioSource = GetComponent<AudioSource>();

       

    }
    
 
    
    // Update is called once per frame
    void Update()
    { 
        AimDir = mousePos.position - transform.position;

       

        if (Input.GetKeyDown(KeyCode.Space) && (dashCount < maxDashCount) && IsInvulnerable == false)
        { 

            CancelInvoke("StartDashCD");

            Dash(MoveDir);
            //play sound
            audioSource.Play();
            Debug.Log("Player Dashed");
            //play animation
            Animator.SetTrigger("Dash");

            dashCount++;
            Debug.Log(dashCount);
            //reset and start dash cooldown timer
            Invoke("StartDashCD", dashCoolDownTime);

            return;
        }

        if (IsInvulnerable)
        { 
            Invoke("BecomeVulnerable", 0.5f);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !IsInvulnerable && !IsStunned)
        {  
            Attack(MoveDir);
        }

    }
    

    private void FixedUpdate()
    {
        Move();




    }

    public override void Move()
    {
        if (IsStunned)
        {

            Invoke("UnStunned", 0.5f);
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        


        

        //if looking right and clicked left(flip to the left)
        //if (faceRight && horizontalInput < 0)
        if(AimDir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

            faceRight = false;


        }
        //if looking left and click right(flip to the right)
        //else if (!faceRight && horizontalInput > 0)
        else if (AimDir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

            faceRight = true;


        }

        //line 69 also got animation variable
        animator.SetFloat("playerDir", AimDir.x);
        animator.SetFloat("xVelocity", Rb.velocity.x);

        MoveDir = new Vector2(horizontalInput, verticalInput).normalized;
        Rb.velocity = MoveDir * MoveSpeed;
        
    }



    public override void Attack(Vector2 attackDr) 
    {
        //if using range weapons then need to use attackDr
        Animator.SetTrigger("Attack");
        Debug.Log("Attack Anim triggered");

        //List<Collider2D> enemyColliders = equippedWeapon.GetEnemyCollider(equippedWeapon.AttackCollider);

        List<Collider2D> enemyColliders = equippedWeapon.AttackCollider.GetComponent<WeaponCollider>().EnemyColliders;

        equippedWeapon.ApplyDamage(enemyColliders, AtkPoint);
        equippedWeapon.ApplyKnockback(enemyColliders);

    }

    public void StartDashCD()
    {
        dashCount = 0;
        Debug.Log(dashCount);
    }
}
