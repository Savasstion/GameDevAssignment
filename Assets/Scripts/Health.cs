using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float hp = 100;
    [SerializeField]
    private float maxHP = 100;
    [SerializeField]
    GameObject levelChecker;


    public float Hp { get => hp; set => hp = value; }
    public float MaxHP { get => maxHP; set => maxHP = value; }
    public GameObject LevelChecker { get => levelChecker; set => levelChecker = value; }

    private void Start()
    {
        Hp = 100;
        MaxHP = 100;
    }

    IEnumerator damageFeedback()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator healFeedback()
    {
        this.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        this.GetComponent<SpriteRenderer>().color = Color.green;
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
                this.Hp -= 0;
            else
            {
                StartCoroutine(this.gameObject.GetComponent<Player>().MakeInvulnerableAfterDamaged());
                this.Hp -= amount;
                this.gameObject.GetComponent<Player>().HitFeedback();
            }
        }
        else if (this.gameObject.CompareTag("Enemy"))
        {
            this.Hp -= amount;
            StartCoroutine(damageFeedback());


        }

        

        if (Hp <= 0)
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

        bool wouldBeOverMaxHealth = Hp + amount > MaxHP;
        StartCoroutine(healFeedback());
        if (wouldBeOverMaxHealth)
        {
            this.Hp = MaxHP;
        }
        else
        {
            this.Hp += amount;
        }
    }

    private void Die()
    {
        this.GetComponent<Actor>().Defeated = true;
        this.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("Dies");
        LevelChecker.GetComponent<CheckCleared>().EnemiesCleared += 1;
        gameObject.GetComponent<Actor>().EnterDefeatState();

        
    }

    

}
