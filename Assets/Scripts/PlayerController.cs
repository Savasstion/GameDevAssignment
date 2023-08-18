using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public Rigidbody2D rg2d;
    


    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetButtonDown("Attack"))
        {

            attack();
        }

    }

    private void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

       


        rg2d.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }

    void attack()
    {
        animator.SetTrigger("Attack");
    }
}
