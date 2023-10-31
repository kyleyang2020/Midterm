using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // for the speed of the character
    // for the player walk anim
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // PLAYER MOVEMENT with wasd
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        // animation for player
        if(playerInput.sqrMagnitude > 0)
            animator.Play("playerWalk");
        else
            animator.Play("playerStand");

        // moves player, normalized to fix speed when moving diagonally
        // Time.deltaTime to make movement framerate dependent
        rb.velocity = playerInput.normalized * speed;
    }
}
