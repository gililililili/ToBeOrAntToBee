using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float jumpForce = 5f;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckRadius = 0.2f;
    [SerializeField] protected LayerMask groundLayer;
    public void jump()
    {
        rb.linearVelocityY = jumpForce;
    }
    public void move(int direction)
    {
        rb.linearVelocityX = direction * speed;
    }
    public bool checkGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    public Rigidbody2D getRigidbody()
    {
        return rb;
    }
    public float getSpeed()
    {
        return speed;
    }
    public float getJumpForce()
    {
        return jumpForce;
    }
    public void setRigidbody(Rigidbody2D newRb)
    {
        rb = newRb;
    }
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void setJumpForce(float newJumpForce)
    {
        jumpForce = newJumpForce;
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
