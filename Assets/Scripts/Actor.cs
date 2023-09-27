using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField]
    private float atkPoint;
    [SerializeField]
    private float atkSpeed;
    [SerializeField]
    private float hp;
    [SerializeField]
    private bool isInvulnerable;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector2 moveDir;
    [SerializeField]
    private bool isStunned;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float dashDistance;


    public float AtkPoint { get => atkPoint; set => atkPoint = value; }
    public float AtkSpeed { get => atkSpeed; set => atkSpeed = value; }
    public float Hp { get => hp; set => hp = value; }
    public bool IsInvulnerable { get => isInvulnerable; set => isInvulnerable = value; }
  
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }
    public bool IsStunned { get => isStunned; set => isStunned = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public float DashDistance { get => dashDistance; set => dashDistance = value; }

    public abstract void Move();


    public void Dash(Vector2 dashDir)
    {
        IsStunned = true;
        //if (gameObject.GetComponent<Actor>().IsStunned)
           // Debug.Log("Set stunned");
        rb.velocity = Vector2.zero;

        IsInvulnerable = true;
        rb.AddForce(dashDir.normalized * DashDistance, ForceMode2D.Impulse);


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

    public void ChangeColor(Color color)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = color;
    }

    public void EnterDefeatState()
    {
        //set defeatedBool = true;
        ChangeColor(Color.red);
        Invoke("Despawn", 2);
        
    }

    public void Despawn() 
    { 
        Destroy(gameObject);
    }
}













