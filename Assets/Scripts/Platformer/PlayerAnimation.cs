using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    PlayerMovement player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        animator.SetBool("IsGrounded", player.IsGrounded());
        animator.SetFloat("XSpeed", Mathf.Abs(player.body.velocity.x));
        animator.SetFloat("YSpeed", player.body.velocity.y);
        animator.SetBool("Dash", player.dashing);
    }
}
