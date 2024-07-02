using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //Este script controla todo el movimiento y todas las animaciones del jugador principal.
{
    public float runSpeed = 3;
    public float jumpSpeed = 5;

    Rigidbody2D rb2D;

    public bool betterJump = false;
    public float fallJumpMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;

    public Animator animator;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate() // aqui controlamos las direcciones del jugador y asignamos las animaciones pertinentes. Tambien incluyo el BetterJump para ganar mas salto al presionar mas el espacio.
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true); 
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("space") && CheckFloor.isFloor)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            animator.SetBool("Jump", true); 
        }

        if (!CheckFloor.isFloor)
        {
            animator.SetBool("Jump", true); 
        }
        else
        {
            animator.SetBool("Jump", false); 
        }

        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallJumpMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}