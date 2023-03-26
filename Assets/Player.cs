using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocity;
    public float score;
    public Rigidbody2D rb;
    public Transform shootingPoint;
    public GameObject bullet;
    public TMP_Text scoreText;
    public Button restartButton;
    public TMP_Text gameOverText;


    private void Update()
    {
        FaceMouse();
        var movementH = Input.GetAxis("Horizontal");
        var movementV = Input.GetAxis("Vertical");

        transform.position += new Vector3(movementH, movementV, 0) * Time.deltaTime * velocity;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, shootingPoint.position, transform.rotation);
        }
        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Meteor"))
        {
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
