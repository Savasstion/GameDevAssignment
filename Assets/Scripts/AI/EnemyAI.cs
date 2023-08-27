using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f;


    private void Start()
    {
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    private void PerformDetection() 
    {
    for(int i = 0; i < detectors.Count; i++) 
        {
            detectors[i].Detect(aiData);
        }
    }

}
