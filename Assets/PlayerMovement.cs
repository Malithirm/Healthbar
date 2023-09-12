using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float dirX = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * moveSpeed, 0f);
    }
}
