using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelfTargetSkill : Skill
{
    [SerializeField] GameObject playerGameObj;

    public GameObject PlayerGameObj { get => playerGameObj; set => playerGameObj = value; }
}
