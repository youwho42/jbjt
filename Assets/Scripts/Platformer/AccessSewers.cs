using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AccessSewers : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera sewerCam;

    public GameObject player;

    public GameObject sewerEntrance;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
            sewerCam.Priority = 100;

            player.transform.position = sewerEntrance.transform.position;
            
        }
    }
}
