using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void Update()
    {
        if(transform.position.x <= -15 || transform.position.x >= 15 || transform.position.y >= 10 || transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
