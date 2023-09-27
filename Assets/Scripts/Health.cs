using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float hp = 100;
    [SerializeField]
    private float maxHP = 100;

    private void Start()
    {
        hp = 100;
        maxHP = 100;
    }
    public void Damage(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.hp -= amount;

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = hp + amount > maxHP;

        if (wouldBeOverMaxHealth)
        {
            this.hp = maxHP;
        }
        else
        {
            this.hp += amount;
        }
    }

    private void Die()
    {
        Debug.Log("Dies");
        Destroy(this.gameObject);
    }
}
