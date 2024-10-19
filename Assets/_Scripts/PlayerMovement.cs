using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player
    public Rigidbody2D rb;        // Reference to the Rigidbody2D component
    public Animator animator;     // Reference to the Animator component
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component

    private Vector2 movement;     // Stores movement input

    void Update()
    {
        // Get input from keyboard (WASD or arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Check if the player is moving
        if (movement != Vector2.zero)
        {
            // Horizontal movement: handle left/right turning
            if (movement.x != 0)
            {
                // Set the right or left animation using the Idle_Right animation
                animator.Play("Idle_Right");  // Play the Idle_Right animation
                
                // Flip the sprite if moving left
                spriteRenderer.flipX = movement.x < 0;
            }
            // Vertical movement: handle up/down animations
            else if (movement.y != 0)
            {
                // Set the up or down animation
                if (movement.y > 0)
                {
                    animator.Play("Idle_Up");  // Play Idle_Up when moving up
                }
                else
                {
                    animator.Play("Idle_Down");  // Play Idle_Down when moving down
                }
                
                // Ensure the sprite isn’t flipped for vertical movement
                spriteRenderer.flipX = false;
            }
        }
    }

    void FixedUpdate()
    {
        // Move the player character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
