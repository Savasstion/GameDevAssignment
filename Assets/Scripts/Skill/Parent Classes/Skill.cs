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

    public float SkillCastTime { get => skillCastTime; set => skillCastTime = value; }
    public int SkillCastCost { get => skillCastCost; set => skillCastCost = value; }
    public float SkillCastDelayTime { get => skillCastDelayTime; set => skillCastDelayTime = value; }
    public bool IsUnlock { get => isUnlock; set => isUnlock = value; }
    public int ExpCost { get => expCost; set => expCost = value; }

    public abstract void CastSkill();


}