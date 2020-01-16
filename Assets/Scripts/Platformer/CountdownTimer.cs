using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class CountdownTimer : MonoBehaviour
{
    
    public TextMeshProUGUI countdownTimerText;
    

    public float maxTime;
    float currentTime;
    bool countdownStarted;

    private void Start()
    {
        currentTime = maxTime;
        countdownStarted = false;
        countdownTimerText.text = Mathf.RoundToInt(currentTime).ToString();
    }

    
    private void Update()
    {
        if (countdownStarted)
        {
            
            currentTime -= Time.deltaTime;
            countdownTimerText.text = Mathf.RoundToInt(currentTime).ToString();

            if (currentTime <= 0)
            {
                RespawnPlayer.instance.StartRespawn();
                currentTime = maxTime;
                countdownStarted = false;
            }
        }
        
    }

    

}
