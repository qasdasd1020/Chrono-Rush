using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //Speed of the player movement
    public float jumpForce = 10f; // force applied for jumping
    private Rigidbody2D rb;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //get rigidbody2D component
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();

    }

    void MovePlayer()
    {
        float moveInput = Input.GetAxis("Horizontal"); //get horizontal imput(A/D or left/right arrow key)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); //apply movement
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //Jump when space is pressed and player is grounded
    {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); //apply jump force
            isGrounded = false;
    }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
    
}
