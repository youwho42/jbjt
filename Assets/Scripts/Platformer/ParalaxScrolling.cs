using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScrolling : MonoBehaviour
{

    float length, startpos;
    public GameObject cam;
    public float paralaxAmount;

    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = cam.transform.position.x * (1 - paralaxAmount);
        float dist = cam.transform.position.x * paralaxAmount;

        //transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        transform.position = Vector2.Lerp(transform.position, new Vector3(startpos + dist, transform.position.y, transform.position.z), 1);

        if (temp > startpos + length)
        {
            startpos += length * 2;
        }
        else if (temp < startpos - length)
        {
            startpos -= length * 2;
        }
    }
}
