using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Player player;

    private void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        //rg2d.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }


}
