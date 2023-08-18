using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameController gc;
    int gemValue;
    public string color = "";

    private void Start()
    {
        gc.maxGemCount++;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

            if (color == "green")
                gemValue = 20;
            else if (color == "blue")
                gemValue = 30;
            else
                gemValue = 10;

            Destroy(this.gameObject);
            gc.changeScore(gemValue);

            
            Debug.Log("Enter Collider Gem");
        }
    }
}
