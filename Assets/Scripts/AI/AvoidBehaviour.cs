using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AvoidBehaviour : SteeringBehaviour
{
    [SerializeField]              //agent refers to the enemy
    private float radius = 2f, agentColliderSize = 0.6f;

    [SerializeField]
    private bool showGizmo = true;

    //gizmo parameters
    float[] dangersResultTemp = null;

    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData) 
    {
    
        for(int i = 0; i < aiData.obstacles.Length; i++) 
        {
            Vector2 dirToObstacle = aiData.obstacles[i].ClosestPoint(transform.position) - (Vector2)transform.position;
            float distanceToObstacle = dirToObstacle.magnitude;

            //calculate weight based on the distance between enemy and obstacle
            float weight 
                = distanceToObstacle <= agentColliderSize 
                ? 1  //if distanceToObstacle less than or equal agentColliderSize, return 1 to the weight to not go to that direction
                : (radius - distanceToObstacle) / radius; //if obsatcle very close, avoid weight is higher

            Vector2 dirToObstacleNormalized = dirToObstacle.normalized;

            for(int j = 0; j < Directions.eightDirections.Count; j++) 
            {
                float result = Vector2.Dot(dirToObstacleNormalized, Directions.eightDirections[j]);

                float valueToPutIn = result * weight;

                if(valueToPutIn > danger[j])
                    danger[j] = valueToPutIn;

            } 
        }
        dangersResultTemp = danger;
        return (danger, interest);
    }

    private void OnDrawGizmos()
    {
        if (showGizmo == false)
            return;

        if(Application.isPlaying && dangersResultTemp != null) 
        {
            if (dangersResultTemp != null)
            {
                Gizmos.color = Color.red;
                for (int i = 0; i < dangersResultTemp.Length; i++) 
                {
                    Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * dangersResultTemp[i]);
                }

            }

        }
        else 
        {
            Gizmos.color= Color.cyan;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

    }

}



