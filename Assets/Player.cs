using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    //public float acc;
    public Rigidbody2D rb;

    private void Update()
    {
        FaceMouse();
        var movementH = Input.GetAxis("Horizontal");
        var movementV = Input.GetAxis("Vertical");

        transform.position += new Vector3(movementH, movementV, 0) * Time.deltaTime * velocity;
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
