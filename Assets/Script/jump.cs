using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        // Move the player horizontally
        player.velocity = new Vector2(direction * speed, player.velocity.y);

        // Check for jump input (spacebar)
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply a vertical force to make the player jump
        player.velocity = new Vector2(player.velocity.x, jumpSpeed);
    }

    bool IsGrounded()
    {
        // Implement your grounded check logic here
        // For example, you can use raycasting or check if the player is colliding with the ground
        // Replace the next line with your actual grounded check logic
        // This is a basic placeholder that always returns true, modify it according to your game's needs
        return true;
    }
}
