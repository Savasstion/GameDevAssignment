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

    IEnumerator damageFeedback()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        

        if (this.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.GetComponent<Player>().IsInvulnerable)
                this.hp -= 0;
            else
            {
                StartCoroutine(this.gameObject.GetComponent<Player>().MakeInvulnerableAfterDamaged());
                this.hp -= amount;
                this.gameObject.GetComponent<Player>().HitFeedback();
            }
        }
        else if (this.gameObject.CompareTag("Enemy"))
        {
            this.hp -= amount;
            StartCoroutine(damageFeedback());


        }

        

        if (hp <= 0)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
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
        this.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("Dies");
        gameObject.GetComponent<Actor>().EnterDefeatState();
    }
}
