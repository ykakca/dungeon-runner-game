using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : Potion
{
    //public float duration = 8.0f;
    //public int points = 15;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add coin to counter
            //totalCoins++;
            //Test: Print total number of coins
            //Debug.Log("You currently have " + CoinObject.totalCoins + " Coins.");
            this.gameObject.SetActive(false);
            Destroy(this);
            FindObjectOfType<GameManager>().SpeedPotionCollected(this);
        }
    }

    /*protected override void Collect()
    {
        FindObjectOfType<GameManager>().CoinCollected(this);
    }
    */
}
