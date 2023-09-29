using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public GameObject triggerBox;
    public float delayTime;

    private bool canOpen = false;
    private Collider2D boxCollider;
    private Collider2D triggerCollider;

    void Start()
    {
        boxCollider = GetComponent<Collider2D>();
        triggerCollider = triggerBox.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !canOpen) // ?? "O" ???????????????
        {
            OpenDoor();
        }

        if (Input.GetKeyUp(KeyCode.O) && canOpen) // ?? "O" ???????????????
        {
            CloseDoor();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpen = false;
        }
    }

    void OpenDoor()
    {
        animator.SetTrigger("opening"); // ???????????

        boxCollider.enabled = false;
        triggerCollider.enabled = false;
    }

    void CloseDoor()
    {
        animator.SetTrigger("closing"); // ???????????

        boxCollider.enabled = true;
        triggerCollider.enabled = true;
    }
}
