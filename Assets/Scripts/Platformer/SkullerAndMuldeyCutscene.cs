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


    private void Start()
    {
        player.enabled = false;

        StartCoroutine(DialogueOne());
    }

    IEnumerator DialogueOne()
    {
        skullerText.text = "";
        muldeyText.text = "";
        yield return new WaitForSeconds(3f);
        muldeyText.text = "Look over there Skuller.";
        yield return new WaitForSeconds(2f);
        muldeyText.text = "";
        skullerText.text = "So I see Muldey, it seems a computer cursor has come alive...";
        yield return new WaitForSeconds(2f);
        skullerText.text = "You better get going little guy, the bus is about to leave!";
        yield return new WaitForSeconds(2f);
        skullerText.text = "";
        yield return new WaitForSeconds(8f);
        muldeyText.text = "I'd give you a dollar, but Skuller here hasn't paid me back for the donuts the other day.";
        yield return new WaitForSeconds(2f);
        skullerText.text = "Maybe you can find a few coins as you... how do cursors move? run? over to catch it.";
        yield return new WaitForSeconds(3f);
        skullerText.text = "";
        muldeyText.text = "";
    }

    private void Update()
    {
        if(director.state != PlayState.Playing)
        {
         
            player.enabled = true;
        }
    }
}
