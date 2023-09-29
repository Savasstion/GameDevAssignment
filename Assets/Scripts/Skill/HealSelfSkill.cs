using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSelf : SelfTargetSkill
{
    [SerializeField] float healAmount;

    public override void CastSkill()
    {
        PlayerGameObj.GetComponent<Health>().Heal(healAmount);
    }

    
}
