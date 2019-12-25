using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursyBlinking : MonoBehaviour
{


    SpriteRenderer sprite;
    Color actualColor;
    public Color blinkColor;
    public float blinkRate =.5f;
    

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        actualColor = sprite.color;
        
        InvokeRepeating("Blink", 0, blinkRate);
    }

    void Blink()
    {
        if(sprite.color == actualColor)
        {
            sprite.color = blinkColor;
        }
        else
        {
            sprite.color = actualColor;
        }
    }
}
