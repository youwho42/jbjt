using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float dir { get; private set; }
    public bool jump { get; private set; }
    public bool jumpHold { get; private set; }
    public bool dash { get; private set; }


    private void Update()
    {
        jump = false;
        dir = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
        jumpHold = Input.GetButton("Jump");
        dash = Input.GetKeyDown(KeyCode.Minus);
    }

}
