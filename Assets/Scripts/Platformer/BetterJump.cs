using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BetterJump : MonoBehaviour {



    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
   
    Rigidbody2D rb2d;


    
    PlayerInput playerInput;

    

    private void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

       
        if (rb2d.velocity.y < 0){
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb2d.velocity.y > 0 && !playerInput.jumpHold)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


    }

   
}
