using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    [SerializeField]
    private int factionID;

    public abstract void AlertAllEnemies();
}
