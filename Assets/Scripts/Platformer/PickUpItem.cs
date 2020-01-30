using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public GameObject promptCanvas;
    public bool hasCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            promptCanvas.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                if (hasCoin)
                {
                    hasCoin = false;
                    GameManager.instance.AddCoin();
                    Debug.Log("You got a coin!");
                }
                else
                {
                    Debug.Log("You ain't found s&*#!");
                }
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            promptCanvas.SetActive(false);
        }
    }
}