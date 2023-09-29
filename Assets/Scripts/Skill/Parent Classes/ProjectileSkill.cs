using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSkill : Skill
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    private float projectileSpd;
    [SerializeField]
    GameObject player;


    public override void CastSkill()
    {
        Vector3 Position = new Vector3(transform.position.x,
                                       transform.position.y,
                                       0);


        var projectileInstance = Instantiate(projectile,
                    Position,
                    Quaternion.identity);

        projectileInstance.gameObject.GetComponent<Rigidbody2D>().velocity = player.GetComponent<Player>().AimDir.normalized * projectileSpd;
    }
}