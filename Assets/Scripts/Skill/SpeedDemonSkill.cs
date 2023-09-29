using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDemonSkill : SelfTargetSkill
{
    [SerializeField] short newMaxDodgeCount;
    [SerializeField] float newMoveSpeed;
    [SerializeField] float buffDuration;

    float moveSpeedCache;
    short dodgeMaxAmountCache;

    public override void CastSkill()
    {
        dodgeMaxAmountCache = PlayerGameObj.GetComponent<Player>().MaxDashCount;
        moveSpeedCache = PlayerGameObj.GetComponent<Player>().MoveSpeed;
        StartCoroutine(Buff());
    }

    IEnumerator Buff()
    {
        PlayerGameObj.GetComponent<Player>().MaxDashCount = newMaxDodgeCount;
        PlayerGameObj.GetComponent<Player>().MoveSpeed = newMoveSpeed;
        yield return new WaitForSeconds(buffDuration);
        PlayerGameObj.GetComponent<Player>().MaxDashCount = dodgeMaxAmountCache;
        PlayerGameObj.GetComponent<Player>().MoveSpeed = moveSpeedCache;
    }
}
