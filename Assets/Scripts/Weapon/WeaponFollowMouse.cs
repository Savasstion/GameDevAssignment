using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowMouse : MonoBehaviour
{
    public Player player;
    private Vector2 mouseDir;
   
    void Update()
    {
        
        transform.localScale = Vector3.one;

        Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseDir = (mouseOnScreen - (Vector2)transform.position).normalized;
        if (player.AimDir.x < 0)
        {
            transform.right = -mouseDir;
        }
        else
            transform.right = mouseDir;
    }
}
