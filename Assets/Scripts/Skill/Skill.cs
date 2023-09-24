using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    private float skillCastTime;
    [SerializeField]
    private int skillCastCost;
    [SerializeField]
    private float skillCastDelayTime;
    [SerializeField]
    private bool isUnlock;
    [SerializeField]
    private int expCost;
    public abstract void castSkill();


}