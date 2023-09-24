using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    private float skillCastTime = 0;
    [SerializeField]
    private int skillCastCost = 1;
    [SerializeField]
    private float skillCastDelayTime = 0;
    [SerializeField]
    private bool isUnlock = true;
    [SerializeField]
    private int expCost = 5;
    public abstract void castSkill();


}