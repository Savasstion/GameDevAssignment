using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Animator animator;

    public bool IsInCombat { get => isInCombat; set => isInCombat = value; }
    public bool IsInMenu { get => isInMenu; set => isInMenu = value; }
    public int MaxHP { get => maxHP; set => maxHP = value; }
    public Vector2 LastChkPointCoord { get => lastChkPointCoord; set => lastChkPointCoord = value; }
    public float DefModifier { get => defModifier; set => defModifier = value; }
    public bool IsAllowedDodge { get => isAllowedDodge; set => isAllowedDodge = value; }
    public Animator Animator { get => animator; set => animator = value; }


    // Update is called once per frame
    void Update()
    {



        if (Input.GetButtonDown("Attack"))
        {

            attack(MoveDir, 1);
        }

    }

    private void FixedUpdate()
    {
        Animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Rb.velocity = new Vector2(horizontalInput * MoveSpeed, verticalInput * MoveSpeed);
        //rg2d.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }



    public void usePlayerSkill(int skillNum)
    {

    }

    override
    public void enterDefeatState() 
    {
    
    }

    override
    public void attack(Vector2 attackDr, float range) 
    {
        Animator.SetTrigger("Attack");

    }


}
