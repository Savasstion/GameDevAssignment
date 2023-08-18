using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : Detector
{
    [SerializeField]
    private int detectionRadius = 2;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private bool showGizmos = true;

    Collider2D[] colliders;

    public override void Detect(AIData aiData) 
    {
        colliders = Physics2D.OverlapCircleAll(transform.position,detectionRadius,layerMask);
        aiData.obstacles = colliders;

    }

    private void OnDrawGizmos()
    {
        if(showGizmos == false)
            return;
        if(Application.isPlaying && colliders != null) 
        {
            Gizmos.color = Color.red;
            for(int i = 0; i < colliders.Length; i++)
                Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
            

        }


    }



}
