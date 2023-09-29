using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{

    [SerializeField]
    bool attacking = false;
    [SerializeField]
    GameObject attackArea = default;
    [SerializeField]
    float timeToAttack = .25f;
    float timer = 0f;
    //[SerializeField]
    // float atkPoint;
    //[SerializeField]
    // float atkSpeed;

    [SerializeField]
     bool isInvulnerable;
    [SerializeField]
     float moveSpeed;
    [SerializeField]
     Vector2 moveDir;
    [SerializeField]
     bool isStunned;
    [SerializeField]
     Rigidbody2D rb;
    [SerializeField]
     float dashDistance;
    [SerializeField]
    bool defeated = false;
    [SerializeField]
    Animator animator;

    public GameObject AttackArea { get => attackArea; set => attackArea = value; }
    //public float AtkPoint { get => atkPoint; set => atkPoint = value; }
    //public float AtkSpeed { get => atkSpeed; set => atkSpeed = value; }

    public bool IsInvulnerable { get => isInvulnerable; set => isInvulnerable = value; }
  
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }
    public bool IsStunned { get => isStunned; set => isStunned = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public float DashDistance { get => dashDistance; set => dashDistance = value; }
    
    public bool Attacking { get => attacking; set => attacking = value; }
    public float TimeToAttack { get => timeToAttack; set => timeToAttack = value; }
    public float Timer { get => timer; set => timer = value; }
    public bool Defeated { get => defeated; set => defeated = value; }
    public Animator Animator { get => animator; set => animator = value; }

    public abstract void Move();


    public void Dash(Vector2 dashDir)
    {
        IsStunned = true;
        //if (gameObject.GetComponent<Actor>().IsStunned)
           // Debug.Log("Set stunned");
        rb.velocity = Vector2.zero;

        IsInvulnerable = true;
        rb.AddForce(dashDir.normalized * DashDistance , ForceMode2D.Impulse);


    }


    public void UnStunned()
    {
        IsStunned = false;
        Rb.velocity = Vector2.zero;
        CancelInvoke("UnStunned");
    }
    public void BecomeVulnerable() 
    {
        IsInvulnerable = false;
        CancelInvoke("BecomeVulnerable");
    }

    public void Teleport(Vector2 destination)
    {
        transform.position = destination;
    }

    public abstract void Attack(Vector2 aimDir);


    public void EnterDefeatState()
    {
        defeated = true;
        this.GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("Despawn", 1);
        transform.right = new Vector2(0, 1);
    }

    public void Despawn() 
    {
    Destroy(gameObject);
    
    }


    public bool CheckIfDefeated()
    {
        if (Defeated)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            IsStunned = true;
            return true;
        }
        else { return false; }
    }
}













