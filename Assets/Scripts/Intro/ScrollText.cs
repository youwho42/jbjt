using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour
{
    public Canvas introText;
    public float speed;

    bool reachedPosition;
    
    private void Update()
    {

        float step = speed * Time.deltaTime; // calculate distance to move
        introText.transform.position = Vector3.MoveTowards(introText.transform.position, Vector3.zero, step);
        if(introText.transform.position == Vector3.zero)
        {
            reachedPosition = true;
        }

        if (reachedPosition)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LevelManager.instance.ChangeLevel("Level 1");
            }
        }

    }

    
}
