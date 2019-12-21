using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public LayerMask groundLayer;
    public float direction = 1;

    public Transform groundCheck;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        RaycastHit2D hitGround = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);
        if (!hitGround)
        {
            direction *= -1;
            FlipSpriteDirection();
        }
    }
    void FlipSpriteDirection()
    {
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
