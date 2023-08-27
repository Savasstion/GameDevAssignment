using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextSolver : MonoBehaviour
{
    [SerializeField]
    private bool showGizmos = true;

    //gizmo parameters
    float[] interestGizmo = new float[8];
    Vector2 resultDir = Vector2.zero;
    private float rayLength = 1f;

    public Vector2 GetDirToMove(List<SteeringBehaviour> behaviours, AIData aiData) 
    {
        float[] danger = new float[8];
        float[] interest = new float[8];

        for (int i = 0; i < behaviours.Count; i++) 
        {
            (danger, interest) = behaviours[i].GetSteering(danger, interest, aiData);
        }

        for (int i = 0; i < 8; i++) 
        {
            interest[i] = Mathf.Clamp01(interest[i] - danger[i]);
        }

        interestGizmo = interest;

        Vector2 outputDir = Vector2.zero;
        for(int i =0; i < 8; i++) 
        {
            outputDir += Directions.eightDirections[i] * interest[i];
        }
        
        outputDir.Normalize();
        resultDir = outputDir;

        return resultDir;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying && showGizmos)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, resultDir * rayLength);
        }
    }

}
