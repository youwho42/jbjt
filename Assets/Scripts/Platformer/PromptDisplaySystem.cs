using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptDisplaySystem : MonoBehaviour
{

    public GameObject promptCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            promptCanvas.SetActive(true);
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
