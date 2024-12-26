using UnityEngine;

/// <summary>
/// Controls character movement and interactions based on player input.
/// </summary>
public class FallingCharacterController : MonoBehaviour
{
    public float speed; // Movement speed of the character.

    private bool hasDecided = false; // Flag to check if a decision has been made.
    private Vector3 targetPosition; // The target position to move towards.
    private bool isMoving = false; // Flag to check if the character is currently moving.
    public string characterTag; // Tag to identify character type ("King" or "Robber").

    /// <summary>
    /// Handles input and movement update every frame.
    /// </summary>
    private void Update()
    {
        // Handle directional input to set target position.
        if (!hasDecided)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveToSide(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveToSide(Vector3.right);
            }
        }

        // Move the character towards the target position.
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false; // Stop moving.
                hasDecided = true; // Decision making complete.
            }
        }
    }

    /// <summary>
    /// Initiates movement in the specified direction.
    /// </summary>
    /// <param name="direction">The direction to move towards.</param>
    private void MoveToSide(Vector3 direction)
    {
        targetPosition = transform.position + direction * 3f; // Set target position based on direction.
        isMoving = true; // Start moving.
    }

    /// <summary>
    /// Triggers actions when entering certain zones, based on the character's tag.
    /// </summary>
    /// <param name="collision">The collider that this character has collided with.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered with {collision.tag} by {characterTag}");

        // Handle different actions based on the zone and character tag.
        if (collision.CompareTag("KingdomZone"))
        {
            if (characterTag == "Robber")
            {
                Debug.Log("Robber entered the Kingdom! Losing a life.");
                if (GameManagerInvadorsGame.Instance != null)
                {
                    GameManagerInvadorsGame.Instance.LoseLife();
                }
            }
            else if (characterTag == "King")
            {
                Debug.Log("King entered the Kingdom! All good.");
            }
        }
        else if (collision.CompareTag("DesertZone"))
        {
            if (characterTag == "King")
            {
                Debug.Log("King sent to the Desert! Losing a life.");
                if (GameManagerInvadorsGame.Instance != null)
                {
                    GameManagerInvadorsGame.Instance.LoseLife();
                }
            }
            else if (characterTag == "Robber")
            {
                Debug.Log("Robber sent to the Desert! All good.");
            }
        }

        // Destroy the character after the interaction.
        Destroy(gameObject);
    }
}
