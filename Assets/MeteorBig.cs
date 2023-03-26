using UnityEngine;

public class MeteorBig : MonoBehaviour
{
    public Rigidbody2D rb;
    private float rotateSpeed;
    private float speed;
    private Vector2 movement;
    public GameObject smallMeteor;
    public float numberOfPieces;

    private void Start()
    {
        if (transform.position.x < 0) movement.x = Random.Range(5f, 10f);
        else movement.x = Random.Range(-10f, -5f);
        if (transform.position.y < 0) movement.y = Random.Range(5f, 10f);
        else movement.y = Random.Range(-10f, -5f);
        rotateSpeed = Random.Range(-30f, 30f);
        speed = Random.Range(3f, 5f);
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        rb.AddForce(movement * speed * Time.deltaTime);

        if (transform.position.x <= -13 || transform.position.x >= 13 || transform.position.y >= 9 || transform.position.y <= -9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            for (int i = 0; i < numberOfPieces; i++)
            {
                Instantiate(smallMeteor, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
