using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : Enemy
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



    

    private void Start()
    {
        IsStunned = false;
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

    public override void Move()
    {
        if (IsStunned)
        {

            Invoke("UnStunned", 0.5f);
            return;
        }
        MoveDir = Rb.velocity = movementDirectionSolver.GetDirToMove(steeringBehaviours, aiData) * speed;
    }



    public override void Attack(Vector2 attackDr, float range)
    {
        throw new System.NotImplementedException();
    }

    public override void AlertAllEnemies()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateQuest()
    {
        throw new System.NotImplementedException();
    }
}
