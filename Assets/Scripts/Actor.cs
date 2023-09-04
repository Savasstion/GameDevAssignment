using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField]
    private int atkPoint;
    [SerializeField]
    private float atkSpeed;
    [SerializeField]
    private int hp;
    [SerializeField]
    private bool isInvulnerable;
    [SerializeField]
    private Vector2 aimVector;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector2 moveDir;
    [SerializeField]
    private float knockbackModifier;
    [SerializeField]
    private bool isStunned;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float dashDistance;

    public int AtkPoint { get => atkPoint; set => atkPoint = value; }
    public float AtkSpeed { get => atkSpeed; set => atkSpeed = value; }
    public int Hp { get => hp; set => hp = value; }
    public bool IsInvulnerable { get => isInvulnerable; set => isInvulnerable = value; }
    public Vector2 AimVector { get => aimVector; set => aimVector = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }
    public float KnockbackModifier { get => knockbackModifier; set => knockbackModifier = value; }
    public bool IsStunned { get => isStunned; set => isStunned = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public float DashDistance { get => dashDistance; set => dashDistance = value; }

    public void dash() 
    {
        
        rb.AddForce(MoveDir * DashDistance, ForceMode2D.Impulse);


    }

    public abstract void enterDefeatState();



    public void teleport(Vector2 destination) 
    {
        transform.position = destination;
    }

    public abstract void attack(Vector2 aimDir, float atkRange);

    
    
   
    

   
    



}
