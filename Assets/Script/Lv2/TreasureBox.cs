using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject coin;
    public GameObject triggerBox; // ???Collider???GameObject
    public float delayTime;       // coin Dropping time

    private bool canOpen = true;
    private bool isOpened = false;
    private Animator anim;
    private Collider2D boxCollider; // ???Collider
    private Collider2D triggerCollider; // ???Collider

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
        boxCollider = GetComponent<Collider2D>();
        triggerCollider = triggerBox.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I key pressed");

            if (canOpen && !isOpened)
            {
                anim.SetTrigger("Opening");
                isOpened = true;

               
                boxCollider.enabled = false;
                triggerCollider.enabled = false;

                Invoke("GetCoin", delayTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    void GetCoin()
    {

        Instantiate(coin, transform.position, Quaternion.identity);

   
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpen = false;
        }
    }
}
