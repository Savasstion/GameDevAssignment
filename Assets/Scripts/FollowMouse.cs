using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    Vector3 mousePos;
    [SerializeField]
    Vector3 mousePosition;

        void Update(){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = mousePos;
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }
    
}
