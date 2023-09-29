using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;


    private void Awake()
    {
        StartCoroutine(DestroyAfterDelay(3f));
    }
    public float Damage { get => damage; set => damage = value; }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        this.gameObject.SetActive(false);
        Destroy(gameObject.transform.parent.gameObject, delay);



    }

}
