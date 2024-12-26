using UnityEngine;
using UnityEngine.SceneManagement; // ���� ����� ��� �����

/// <summary>
/// Manages the end point of the game, handling when the player reaches the game's conclusion.
/// </summary>
public class EndPointTrigger : MonoBehaviour
{
    /// <summary>
    /// Detects collision with the player and triggers the end of the game.
    /// </summary>
    /// <param name="collision">Information about the collision event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger end game if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }
    /// <summary>
    /// Loads the victory scene to display the game's successful completion.
    /// </summary>
    private void EndGame()
    {
        SceneManager.LoadScene("VictoryScene");// Load the victory scene when the game ends
    }
}
