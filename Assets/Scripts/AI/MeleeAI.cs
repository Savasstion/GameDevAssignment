using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : MonoBehaviour
{
    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private List<SteeringBehaviour> steeringBehaviours;

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, speed;

    [SerializeField]
    private ContextSolver movementDirectionSolver;

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private bool isStunned = false;


    public bool IsStunned { get => isStunned; set => isStunned = value; }

    private void Start()
    {
        isStunned = false;
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    private void FixedUpdate()
    {
        //rb2d.velocity = Vector2.zero;

        Move();

       

    }

    private void PerformDetection() 
    {
        for(int i = 0; i < detectors.Count; i++) 
        {
            detectors[i].Detect(aiData);
        }

        
    }

    private void Move()
    {
        if (isStunned)
        {

            Invoke("UnStunned", 0.5f);
            return;
        }
        rb2d.velocity = movementDirectionSolver.GetDirToMove(steeringBehaviours, aiData) * speed;
    }

    private void UnStunned() {
        isStunned = false;
        rb2d.velocity = Vector2.zero;
       CancelInvoke("UnStunned");
    }
}
