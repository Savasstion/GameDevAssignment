using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSkill : MonoBehaviour
{
    [SerializeField]
    private int skillPlaced = 0;
    [SerializeField]
    private int maxPlacementAmount = 1;
    [SerializeField]
    private float skillRadius = 30f;
    [SerializeField]
    private LayerMask enemyLayerMask;

    //private List<Collider2D> colliders;
    private Collider2D[] colliders;

    public void getEnemyCollider() {
        colliders = Physics2D.OverlapCircleAll(transform.position, skillRadius, enemyLayerMask);

    }

}
