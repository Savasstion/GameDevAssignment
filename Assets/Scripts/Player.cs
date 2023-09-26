using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : Actor
{
    [SerializeField]
    private bool isInCombat;
    [SerializeField]
    private bool isInMenu;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private Vector2 lastChkPointCoord;
    [SerializeField]
    private float defModifier;
    [SerializeField]
    private bool isAllowedDodge;
    [SerializeField]
    private Transform aimDir;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private short dashCount = 0, maxDashCount;
    [SerializeField]
    private float dashCoolDownTime;

    public AudioSource audioSource;


    public bool IsInCombat { get => isInCombat; set => isInCombat = value; }
    public bool IsInMenu { get => isInMenu; set => isInMenu = value; }
    public int MaxHP { get => maxHP; set => maxHP = value; }
    public Vector2 LastChkPointCoord { get => lastChkPointCoord; set => lastChkPointCoord = value; }
    public float DefModifier { get => defModifier; set => defModifier = value; }
    public bool IsAllowedDodge { get => isAllowedDodge; set => isAllowedDodge = value; }
    public Transform AimDir { get => aimDir; set => aimDir = value; }
    public Animator Animator { get => animator; set => animator = value; }


    void Start() 
    {
        IsInvulnerable = false;
        //audioSource = GetComponent<AudioSource>();
    }
    
 
    
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && (dashCount < maxDashCount) && IsInvulnerable == false)
        { 

            CancelInvoke("StartDashCD");

            Dash(MoveDir);
            //play sound
            audioSource.Play();
            Debug.Log("Player Dashed");
            //play animation

            dashCount++;
            Debug.Log(dashCount);
            //reset and start dash cooldown timer
            Invoke("StartDashCD", dashCoolDownTime);


        }

        if (IsInvulnerable)
        { 
            Invoke("BecomeVulnerable", 0.5f);
            return;
        }

        if (Input.GetButtonDown("Attack") && !IsInvulnerable)
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

        //uncomment when got animations
        //Animator.SetFloat("Horizontal", horizontalInput);
        //Animator.SetFloat("Vertical", verticalInput);

            

        MoveDir = new Vector2(horizontalInput, verticalInput).normalized;
        Rb.velocity = MoveDir * MoveSpeed;
        
    }



    public override void Attack(Vector2 attackDr) 
    {
        Animator.SetTrigger("Attack");

    }

    public void StartDashCD()
    {
        dashCount = 0;
        Debug.Log(dashCount);
    }
}
