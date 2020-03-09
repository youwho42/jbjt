using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    //public GameObject promptCanvas;
    public bool hasCoin;
    bool isInRange;
    public bool isTrigger;

    public Sprite imageAfterPickUp;
    private SpriteRenderer renderer;

    public GameObject pickUpFX;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;

            if (isTrigger)
            {
                if (hasCoin)
                {
                    hasCoin = false;
                    GameManager.instance.AddCoin();
                    pickUpFX.SetActive(true);
                    Debug.Log("You got a coin!");
                }
                else
                {
                    Debug.Log("You ain't found s&*#!");
                }
            }
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
                    pickUpFX.SetActive(true);
                    Debug.Log("You got a coin!");
                }
                else
                {
                    Debug.Log("You ain't found s&*#!");
                }

                if (imageAfterPickUp != null)
                {
                    ImageSwitchOnPickUp();
                }

            }
        }
    }

    private void ImageSwitchOnPickUp()
    {
        renderer.sprite = imageAfterPickUp;
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}