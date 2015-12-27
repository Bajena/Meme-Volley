using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float maxXSpeed = 10f;
    public float jumpForce = 300f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    bool facingRight = true;
    float groundRadius = 0.2f;
    bool grounded = true;
    
    private Rigidbody2D _rigidBody2D
    {
        get
        {
            return GetComponent<Rigidbody2D>();
        }
    }
	
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        var xMove = Input.GetAxis("Horizontal");

        
        if (xMove > 0 && !facingRight || xMove < 0 && facingRight)
        {
            Flip();
        }

        _rigidBody2D.velocity = new Vector2(xMove * maxXSpeed, _rigidBody2D.velocity.y);
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        var yMove = Input.GetAxis("Vertical");

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody2D.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
