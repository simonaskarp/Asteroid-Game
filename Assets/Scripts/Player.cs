using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocity;
    public float maxBullets;
    public float bulletCount;
    public float bulletRechargeInterval;
    public float nextBullet;
    public TMP_Text bulletText;
    //public float score;
    public Rigidbody2D rb;
    public Transform shootingPoint;
    public GameObject bullet;
    //public TMP_Text scoreText;
    public Button restartButton;
    public TMP_Text gameOverText;
    public AudioSource laser;
    public AudioSource death;


    private void Start()
    {
        nextBullet = Time.time;
        bulletText.text = "BULLETS: " + bulletCount.ToString();
    }

    private void Update()
    {
        FaceMouse();
        var movementH = Input.GetAxis("Horizontal");
        var movementV = Input.GetAxis("Vertical");

        transform.position += new Vector3(movementH, movementV, 0) * Time.deltaTime * velocity;

        if(Input.GetKeyDown(KeyCode.Space) && bulletCount > 0)
        {
            Instantiate(bullet, shootingPoint.position, transform.rotation);
            bulletCount--;
            bulletText.text = "BULLETS: " + bulletCount.ToString();
            laser.Play();
        }

        if(Time.time > nextBullet && bulletCount < maxBullets)
        {
            bulletCount++;
            bulletText.text = "BULLETS: " + bulletCount.ToString();
            nextBullet += bulletRechargeInterval;
        }
        
        //scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("MeteorS") || collision.gameObject.CompareTag("MeteorL"))
        {
            death.Play();
            restartButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 dir = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = dir;
    }
}
