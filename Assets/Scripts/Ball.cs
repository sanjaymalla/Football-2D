using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float slowDownRate = 0.98f;
    [SerializeField] private float minSpeed = 0.1f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.linearVelocity.magnitude > minSpeed)
        {
            rb.linearVelocity *= slowDownRate;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
