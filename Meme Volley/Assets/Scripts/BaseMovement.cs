using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseMovement : MonoBehaviour
{
    public float maxXSpeed = 4f;
    public float jumpForce = 200f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    protected bool facingRight = true;
    protected float groundRadius = 0.2f;
    protected bool grounded = false;
    
    protected Rigidbody2D _rigidBody2D
    {
        get
        {
            return GetComponent<Rigidbody2D>();
        }
    }

    internal abstract float CalculateXMove();
    internal abstract bool ShouldJump();

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        var xMove = CalculateXMove();
        
        if (xMove > 0 && !facingRight || xMove < 0 && facingRight)
        {
            Flip();
        }

        _rigidBody2D.velocity = new Vector2(xMove * maxXSpeed, _rigidBody2D.velocity.y);
    }

    protected void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (grounded && ShouldJump())
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
