using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float kickForce;
    private int jumpCount = 0;

    Rigidbody2D rb;
    Rigidbody2D ballRB;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow)&& jumpCount!=0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
        }
        if (Input.GetKeyDown(KeyCode.Space) && ballRB!=null)
        {
            Kickball();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 2;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
    }

    private void Kickball()
    {
        Vector2 kickDirection = (ballRB.position - (Vector2)transform.position).normalized; // Direction from player to ball
        ballRB.linearVelocity = Vector2.zero; // Reset velocity for a clean force application
        ballRB.AddForce(kickDirection * kickForce, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            ballRB = collision.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            ballRB = null;
        }
    }
}
