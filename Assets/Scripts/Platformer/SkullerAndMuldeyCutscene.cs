using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using System;


public class SkullerAndMuldeyCutscene : MonoBehaviour
{
    public PlayableDirector director;

    public PlayerInput player;



    public TextMeshProUGUI skullerText;
    public TextMeshProUGUI muldeyText;
    public GameObject panel;

    public GameObject startWall;

    bool cutSceneHasPlayed;
    bool timerStarted;


    private void Start()
    {
        skullerText.gameObject.SetActive(false);
        muldeyText.gameObject.SetActive(false);
        panel.SetActive(false);
        director.Pause();
        cutSceneHasPlayed = false;
    }

    IEnumerator DialogueOne()
    {
        skullerText.gameObject.SetActive(true);
        muldeyText.gameObject.SetActive(true);
        panel.SetActive(true);
        skullerText.text = "";
        muldeyText.text = "";
        yield return new WaitForSeconds(1f);
        muldeyText.text = "Look over there Skuller.";
        yield return new WaitForSeconds(4f);
        muldeyText.text = "";
        skullerText.text = "So I see Muldey, it seems a computer cursor has come alive...";
        yield return new WaitForSeconds(6f);
        skullerText.text = "You better get going little guy, the bus is about to leave!";
        yield return new WaitForSeconds(6f);
        skullerText.text = "";
        yield return new WaitForSeconds(10f);
        muldeyText.text = "I'd give you a dollar, but Skuller here hasn't paid me back for the donuts the other day.";
        yield return new WaitForSeconds(6f);
        skullerText.text = "Maybe you can find a few coins as you... how do cursors move? run? over to catch it.";
        yield return new WaitForSeconds(5f);
        skullerText.text = "";
        muldeyText.text = "";
        cutSceneHasPlayed = true;
        panel.SetActive(false);
        skullerText.gameObject.SetActive(false);
        muldeyText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(director.state != PlayState.Playing)
        {
            
            player.enabled = true;
                
           
        }
        else
        {
            
            player.enabled = false;
            if (Input.GetKeyDown(KeyCode.X))
            {
                director.Stop();
                cutSceneHasPlayed = true;
            }
        }
        if (cutSceneHasPlayed && !timerStarted)
        {
            timerStarted = true;
            CountdownTimer.instance.StartCountdown();
            startWall.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !cutSceneHasPlayed)
        {
            if (Input.GetButton("Fire1"))
            {
                StartCoroutine(DialogueOne());
                director.Play();
            }
        }
    }

}
