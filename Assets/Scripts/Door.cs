using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider2D collider2d;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void Start()
    {
     //   spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
     //   collider2d = gameObject.GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
       /* if (CoinObject.totalCoins >= 13) {
            spriteRenderer.sprite = newSprite;
            collider2d.isTrigger = true;
        }*/
        //ChangeSprite();
    }
/*
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }
*/
}
