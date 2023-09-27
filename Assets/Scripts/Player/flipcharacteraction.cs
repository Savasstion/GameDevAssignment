using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pflipcharacteraction : MonoBehaviour
{
    //DustEffect

    public Animator animator;
    public Rigidbody2D rb;




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


        //if not player using this script "= Input.GetAxisRaw("Horizontal");" must change
        //if enemy use script, i will deal with it


        //if left shift is clicked,  enable isDashing
        //if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        //{
        //   StartCoroutine(Dash());
        // }
    }

    void FixedUpdate()
    {
       

       
        Move(horizontalInput);

        


    }

   

    void Move(float horizontal)
    {
        float direction = horizontal;

        //if looking right and clicked left(flip to the left)
        if(faceRight && direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
            faceRight = false;

            
        }
        //if looking left and click right(flip to the right)
        else if (!faceRight && direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            
            faceRight = true;
           
           
        }
       

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
       
    }

    
}
