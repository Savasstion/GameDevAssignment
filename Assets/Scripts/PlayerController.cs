using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public Rigidbody2D rg2d;
    private Rigidbody2D rb;

    private void Start()
    {
        //get the player "Rigidbody2D" component
        rb = GetComponent<Rigidbody2D>();
    }



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

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        //rg2d.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }

    void attack()
    {
        animator.SetTrigger("Attack");
    }
}
