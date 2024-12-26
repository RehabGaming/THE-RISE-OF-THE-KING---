using UnityEngine;

/// <summary>
/// Controls player movement using keyboard input and Rigidbody2D physics.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed; // Speed of player movement.
    private Rigidbody2D rb; // Rigidbody2D component of the player.
    private Vector2 movement; // Vector to store movement direction.

    /// <summary>
    /// Initializes the Rigidbody2D component at the start.
    /// </summary>
    private void Start()
    {
        // Retrieve the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Captures player input from the keyboard each frame.
    /// </summary>
    private void Update()
    {
        // Get player's horizontal and vertical input
        float moveX = Input.GetAxis("Horizontal"); // Movement along the horizontal axis
        float moveY = Input.GetAxis("Vertical"); // Movement along the vertical axis

        // Create a movement vector based on the input
        movement = new Vector2(moveX, moveY);
    }

    /// <summary>
    /// Applies movement to the player's Rigidbody2D based on input.
    /// </summary>
    private void FixedUpdate()
    {
        // Apply the movement vector to the Rigidbody2D velocity, adjusting by speed
        rb.linearVelocity = movement * speed;
    }
}
