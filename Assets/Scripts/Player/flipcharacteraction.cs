using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pflipcharacteraction : MonoBehaviour
{
    //DustEffect
    public ParticleSystem dust;
    public Animator animator;
    public Rigidbody2D rb;

    [SerializeField] Collider2D standingCollider;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] Transform ceilingCheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private TrailRenderer trailRenderer;


    float horizontalInput;
   
    private bool faceRight = true;
 

    




    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        //if(isDashing)
        //{
           // return;
        //}

        //Store the horizontal value
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");



        //if left shift is clicked,  enable isDashing
        //if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        //{
         //   StartCoroutine(Dash());
       // }
    }

    void FixedUpdate()
    {
       

       
        Move();

        


    }

   

    void Move()
    {
        float direction = horizontalInput;

        //if looking right and clicked left(flip to the left)
        if(faceRight && direction < 0)
        {
            transform.localScale = new Vector3(-6, 6, 6);
            
            faceRight = false;

            
        }
        //if looking left and click right(flip to the right)
        else if (!faceRight && direction > 0)
        {
            transform.localScale = new Vector3(6, 6, 6);
            
            faceRight = true;
           
           
        }
       

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
       
    }

    
}
