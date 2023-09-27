using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowMouse : MonoBehaviour
{
    public Transform mouse;
    private Vector2 mouseDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseDir = (mouse.position - transform.position).normalized;
        transform.right = mouseDir;
    }
}
