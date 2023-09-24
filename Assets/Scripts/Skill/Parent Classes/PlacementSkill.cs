using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacementSkill : Skill
{
    [SerializeField]
    private int skillPlaced = 0;
    [SerializeField]
    private int maxPlacementAmount = 1;
    [SerializeField]
    private float skillRadius = 30f;
    [SerializeField]
    private LayerMask enemyLayerMask;



    public float SkillRadius { get => skillRadius; set => skillRadius = value; }

    public Collider2D[] getEnemyCollider() {
        return Physics2D.OverlapCircleAll(transform.position, skillRadius, enemyLayerMask);

    }

  

}
