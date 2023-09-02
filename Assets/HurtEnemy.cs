using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private Animator parent;
    bool isAttack;
    GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Attack"))
        {
            isAttack = true;
            parent.SetBool("Attack", true);
        }

        if (Input.GetButtonUp("Attack"))
        {
            isAttack = false;
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1);
            Destroy(enemy);
            isAttack = false;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            if (isAttack)
            {
                enemy = other.gameObject;
                StartCoroutine(Wait());
            }

        }
    }

}
