using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed;

    public float platformStartPosition;
    public float platformEndPosition;


    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(transform.position.x >= platformEndPosition)
        {
            transform.position = new Vector2(platformStartPosition, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector2(platformStartPosition, transform.position.y), 0.3f);
        Gizmos.DrawWireSphere(new Vector2(platformEndPosition, transform.position.y), 0.3f);
    }
}
