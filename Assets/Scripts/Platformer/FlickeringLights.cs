using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class FlickeringLights : MonoBehaviour
{

    public Light2D lightToFlicker;
    [Range(0.0f,1.0f)]
    public float chanceToFlicker;
    [Range(0.0f, 1.0f)]
    public float flickerRate;
    public Vector2 minMaxTimeBetweenFlickers;
    float timeToNextFlicker;
    float currentFlickerTime;
    bool willFlicker;
    bool isFlickering;

    private void Start()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if(rand <= chanceToFlicker)
        {
            willFlicker = true;
            
        }
    }

    private void Update()
    {
        if (willFlicker)
        {
            currentFlickerTime += Time.deltaTime;
            if(currentFlickerTime >= timeToNextFlicker && !isFlickering)
            {
                isFlickering = true;
                StartCoroutine("FlickerLightCo");
                currentFlickerTime = 0;
            }
        }
    }

    IEnumerator FlickerLightCo()
    {
        for (int i = 0; i < 5; i++)
        {
            float rand = Random.Range(0.0f, 1.0f);
            lightToFlicker.intensity = rand;
            yield return new WaitForSeconds(flickerRate);
        }
        timeToNextFlicker = Random.Range(minMaxTimeBetweenFlickers.x, minMaxTimeBetweenFlickers.y);
        isFlickering = false;
        lightToFlicker.intensity = 1.0f;
        yield return null;
    }
}
