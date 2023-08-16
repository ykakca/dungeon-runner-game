using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 MovementVector { get; private set; }   
    public event Action<Vector2> OnMovement;   
    public Image deadScreen;
    public bool isEnemyFrightened;
    public int score;

    [SerializeField]
    private MobileJoystick joystick;
    
    private Rigidbody2D rigidbody2d;
    private Vector3 movementDirection;
    public float speed = 2;

/*
    private void Start()
    {
        joystick.OnMove += Move;
    }

    private void Move(Vector2 input)
    {
        MovementVector = input;
        OnMovement?.Invoke(MovementVector);
    }

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

*/

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        joystick.OnMove += MovePlayer;
    }

    private void MovePlayer(Vector2 input)
    {
        //ex
        rigidbody2d.velocity = input * speed;
    }
/*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            FindObjectOfType<GameManager>().PlayerDead();
            this.deadScreen.enabled = true;
        }
    }
*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (!isEnemyFrightened) {
                FindObjectOfType<GameManager>().PlayerDead();
                this.deadScreen.enabled = true;
            } else {
                //FindObjectOfType<GameManager>().EnemyDead(collision.gameObject);
                Destroy(collision.gameObject);
                FindObjectOfType<GameManager>().SetScore(score + 200);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("InvinciblePot")) {
            isEnemyFrightened = true;
        }
    }

/*
    void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = movementDirection * speed;
    }
*/
    
}
