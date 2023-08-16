using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyFrightened frightened { get; private set; }
    public Transform target;
    public int points = 200;
    public bool isFrightened;

    private void Awake()
    {
        this.frightened = GetComponent<EnemyFrightened>();
    }

    private void Start()
    {
        ResetState();
        isFrightened = true;
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        //this.frightened.Disable();
        this.frightened.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Passage")) {
            Destroy(this.gameObject);
        }
    }
/*
    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }
*/
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!isFrightened) {
                FindObjectOfType<GameManager>().PlayerDead();
            } else {
                FindObjectOfType<GameManager>().EnemyDead(this);
                Destroy(this);
            }
        }
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<GameManager>().EnemyDead(this);
            //Destroy(this);
        }
    }*/
}

