using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 cache;
    void Update()
    {
        if (player != null)
            transform.position = cache = new Vector3(player.transform.position.x, player.transform.position.y, -1);
        else
            transform.position = cache;
    }
}
