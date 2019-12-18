using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform objectToFollow;
    public float offset;
    Vector3 followObjectPosition;
    public float offsetSmooting;
    public float offsetSmootingMultiplier;
    Vector3 previousPlayerPosition;
    public bool centerWhenIdle;
    

    // Update is called once per frame
    void LateUpdate()
    {
        float smoothAmount = offsetSmooting;

        followObjectPosition = new Vector3(objectToFollow.position.x, transform.position.y, transform.position.z);
        if (centerWhenIdle)
        {
            if (previousPlayerPosition != followObjectPosition)
            {
                previousPlayerPosition = followObjectPosition;
                followObjectPosition = new Vector3(followObjectPosition.x + (offset * objectToFollow.localScale.x), followObjectPosition.y, followObjectPosition.z);
                smoothAmount *= offsetSmootingMultiplier;
            }
        }
        else
        {
            followObjectPosition = new Vector3(followObjectPosition.x + (offset * objectToFollow.localScale.x), followObjectPosition.y, followObjectPosition.z);
        }
        
        //else
        //{
        //    followObjectPosition = new Vector3(followObjectPosition.x + (offset * objectToFollow.localScale.x), followObjectPosition.y, followObjectPosition.z);
        //}

        //followObjectPosition = new Vector3(followObjectPosition.x + (offset * objectToFollow.localScale.x), followObjectPosition.y, followObjectPosition.z);
        
        transform.position = Vector3.Lerp(transform.position, followObjectPosition, smoothAmount * Time.deltaTime);
    }
}
