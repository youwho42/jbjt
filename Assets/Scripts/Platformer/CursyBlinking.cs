using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CursyBlinking : MonoBehaviour
{

    public float blinkRate =.5f;
    public Light2D light;
    
    

    private void Start()
    {
        
        InvokeRepeating("Blink", 0, blinkRate);
    }

    

    void Blink()
    {
        if(light.intensity == 1)
        {
            light.intensity = 0.5f;
        }
        else
        {
            light.intensity = 1;
        }
    }
}
