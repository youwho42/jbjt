using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    //public GameObject promptCanvas;
    public bool hasCoin;
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

        if (isInRange)
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
            isInRange = false;
        }
    }
}