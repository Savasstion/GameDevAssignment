using UnityEngine;

public class CollectKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Key"))
        {
         
            Destroy(other.gameObject);
        }
    }
}
