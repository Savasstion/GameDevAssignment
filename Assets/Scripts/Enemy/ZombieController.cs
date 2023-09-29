using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    Vector3 toPlayerVec;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goToPlayer();
    }

    void goToPlayer() {
        toPlayerVec = (GameObject.FindGameObjectWithTag("Player").transform.position) - transform.position;

        transform.Translate(toPlayerVec * moveSpeed);
    }
}
