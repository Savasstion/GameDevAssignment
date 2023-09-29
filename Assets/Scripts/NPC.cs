using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Actor
{
    [SerializeField]
    private bool isHostile;
    [SerializeField]
    private bool isInteractable;
    [SerializeField]
    private int questID;

    public void StartConvo() { throw new System.NotImplementedException(); }
    public abstract void UpdateQuest();

}
