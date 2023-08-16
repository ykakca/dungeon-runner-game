using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 4.0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    //-523.4793f, 517.9689f
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -400.0f) {
            transform.position = startPosition;
        }
    }
}
