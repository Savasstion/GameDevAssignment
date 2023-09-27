using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private float knocbackModifier, atkModifier, atkSpdModifier;
    [SerializeField]
    private GameObject weaponCollider;
    [SerializeField]
    private bool isMelee;

    private ContactFilter2D contactFilter;
    

    public float KnocbackModifier { get => knocbackModifier; set => knocbackModifier = value; }
    public float AtkModifier { get => atkModifier; set => atkModifier = value; }
    public float AtkSpdModifier { get => atkSpdModifier; set => atkSpdModifier = value; }
    public bool IsMelee { get => isMelee; set => isMelee = value; }
    public GameObject WeaponCollider { get => weaponCollider; set => weaponCollider = value; }

    private void Start()
    {
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.NameToLayer("Enemy"));
        
    }


    public Collider2D[] GetEnemyCollider(Transform mouse)
    {
        //List<Collider2D> colliders = new List<Collider2D>();
        //Collider2D attackCollider = weaponCollider.GetComponent<Collider2D>();


        //Physics2D.OverlapCollider(attackCollider, contactFilter, colliders);

        //List<Collider2D> enemyColliders = new List<Collider2D>();  
        //foreach (Collider2D overlapCollider in colliders)
        //    enemyColliders.Add(overlapCollider);



        //Debug.Log("enemyColliders returned");
        //Debug.Log("Collider amount = " + enemyColliders.Count);
        //colliders = null;

        //return enemyColliders;

        return Physics2D.OverlapCircleAll(transform.position + (mouse.position.normalized / 3),
            1);
    }

    public void ApplyDamage(Collider2D[] enemyColliders, float atkPoint) 
    {
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            //test
            Destroy(enemyColliders[i].gameObject);

            Debug.Log("enemyColliders[i] layer number = " + enemyColliders[i].gameObject.layer);
            if (/*enemyColliders[i] != null && */(LayerMask.NameToLayer("Enemy") == enemyColliders[i].gameObject.layer)
                /*&& enemyColliders[i].gameObject.CompareTag("EnemyHitbox")*/)
            {
                enemyColliders[i].gameObject.transform.parent.GetComponent<Actor>().Hp -= (atkModifier * atkPoint);

                Debug.Log("Applied Damage");
                //enemyColliders[i].gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else {
                Debug.Log("Failed to do damage");
            }
        }
    
    }

    public void ApplyKnockback(Collider2D[] enemyColliders) 
    {
 
        //deals knockback from the transform pos
        //
        Transform posCache;


        for (int i = 0; i < enemyColliders.Length; i++)
        {
            if (enemyColliders[i] != null && LayerMask.NameToLayer("Enemy") == enemyColliders[i].gameObject.layer
                && enemyColliders[i].gameObject.CompareTag("EnemyHitbox"))
            {
                Debug.Log("Rigidbody2D assigned");
                
                if (enemyColliders[i].gameObject.transform.parent.TryGetComponent<Rigidbody2D>(out var rbEnemy))
                {

                    enemyColliders[i].gameObject.transform.parent.GetComponent<Actor>().IsStunned = true;


                    posCache = rbEnemy.transform;

                    Vector2 toEnemyDir = posCache.position - transform.position;


                    //Debug.Log(knockbackDistance);

                    rbEnemy.velocity = Vector2.zero;
                    //rb.AddForce(toEnemyDir.normalized * explosionStrength, ForceMode2D.Impulse);
                    rbEnemy.AddForce(knocbackModifier * toEnemyDir.normalized, ForceMode2D.Impulse);
                    Debug.Log("Added Knockback");



                }
                else { Debug.Log("RB is null"); }
            }
            else 
            {
                Debug.Log("Failed to add Knockback");

            }
        }


    }

=======
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> Stashed changes
}
