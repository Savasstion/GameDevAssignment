using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private List<SteeringBehaviour> steeringBehaviours;

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, speed = 1;

    [SerializeField]
    private ContextSolver movementDirectionSolver;

    [SerializeField]
    private Rigidbody2D rb2d;

    private void Start()
    {
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    private void Update()
    {
        rb2d.velocity = movementDirectionSolver.GetDirToMove(steeringBehaviours, aiData) * speed;
    }

    private void PerformDetection() 
    {
        for(int i = 0; i < detectors.Count; i++) 
        {
            detectors[i].Detect(aiData);
        }

        
    }

    

}
