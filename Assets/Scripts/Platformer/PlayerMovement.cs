using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
    float currentSpeed;
	public float jumpForce;
    [Range(0.0f, 1.0f)]
    public float airSpeedMultiplier;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    [HideInInspector]
    public Rigidbody2D body;
    PlayerInput input;
    public LayerMask groundLayer;
    public Vector2 groundCheckSize;
    public SpriteRenderer sprite;
    [HideInInspector]
    public bool facingLeft;
    [HideInInspector]
    public bool dashing;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        currentSpeed = speed;
    }

    private void Update()
    {
       
        // Jump logic
        if (input.jump && IsGrounded())
        {
            body.AddForce(Vector2.up * jumpForce);
        }

        if (body.velocity.y < 0)
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (body.velocity.y > 0 && !input.jumpHold)
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (input.dash && !dashing)
        {
            dashing = true;
        }
        

        // Change speed if in the air
        currentSpeed = IsGrounded() ? speed : speed * airSpeedMultiplier;
        
        // Change sprite ditection depending on movement
        if (input.dir > 0 && facingLeft)
        {
            FlipSpriteDirection();
        }
        else if(input.dir < 0 && !facingLeft)
        {
            FlipSpriteDirection();
        }

        
    }

    void DashReset()
    {
        dashing = false;
    }


    void Dash()
    {
        body.AddForce(Vector2.right * 2000 * transform.localScale.x);
    }

    private void FixedUpdate()
    {
        if (dashing)
        {
            Dash();
            Invoke("DashReset", .25f);
        }
        // Actually move the player
        body.velocity = new Vector2(input.dir * currentSpeed * Time.fixedDeltaTime, body.velocity.y);
    }

    // Check if the player is on the ground
    public bool IsGrounded()
    {
        RaycastHit2D hit;
        Vector2 boxSize = groundCheckSize;
        hit = Physics2D.BoxCast(transform.position - new Vector3(0, sprite.bounds.extents.y + boxSize.y + 0.01f, 0), boxSize, 0, Vector2.down, boxSize.y, groundLayer);

        if (hit)
        {
            return true;
        }
        return false;
    }

    // Actually change sprite direction
    void FlipSpriteDirection()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
   
}
