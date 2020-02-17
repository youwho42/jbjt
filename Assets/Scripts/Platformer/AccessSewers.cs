using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AccessSewers : MonoBehaviour
{
    
    public CinemachineStateDrivenCamera sewerStateCamera;
    public CinemachineStateDrivenCamera mainStateCamera;

    public GameObject player;
    public LayerMask playerLayer;

    public Transform sewerEntrance;
    public Transform sewerExit;

    bool isInRange;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isInRange = true;
        }
    }

    private void Update()
    {

        Collider2D entranceHit = Physics2D.OverlapCircle(sewerEntrance.position, 1.0f, playerLayer);
        if(entranceHit != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                BlackOutScreen.instance.BlackOut();
                sewerStateCamera.Priority = 100;
                mainStateCamera.Priority = 10;

                player.transform.position = sewerExit.position;
            }
        }

        Collider2D exitHit = Physics2D.OverlapCircle(sewerExit.position, 1.0f, playerLayer);
        if (exitHit != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                BlackOutScreen.instance.BlackOut();
                sewerStateCamera.Priority = 10;
                mainStateCamera.Priority = 100;

                player.transform.position = sewerEntrance.position;
            }
        }

    }

   

    private void OnDrawGizmosSelected()
    {
        if(sewerEntrance != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(sewerExit.position, sewerEntrance.position);
        }
        
    }
}
