using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public LayerMask groundLayer;
    public LayerMask obstacleLayer;
    public float direction = 1;

    public Transform groundCheck;
    public Transform obstacleCheck;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        Collider2D hitGround = Physics2D.OverlapCircle(groundCheck.position, .25f, groundLayer);
        Collider2D hitObstacle = Physics2D.OverlapCircle(obstacleCheck.position, .25f, obstacleLayer);
        //RaycastHit2D hitGround = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);
        if (hitGround == null || hitObstacle != null)
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
