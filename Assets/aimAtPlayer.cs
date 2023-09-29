using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimAtPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        transform.right = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
    }
}
