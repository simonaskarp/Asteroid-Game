using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSmall : MonoBehaviour
{
    public Rigidbody2D rb;
    private float rotateSpeed;
    private float speed;
    private Vector2 movement;

    private void Start()
    {
        movement = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        rotateSpeed = Random.Range(-40f, 40f);
        speed = Random.Range(-5f, 5f);
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        rb.AddForce(movement * speed * Time.deltaTime);
    }
}
