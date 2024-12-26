using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the game over behaviors, specifically handling game restarts.
/// </summary>
public class GameOverManager : MonoBehaviour
{
    /// <summary>
    /// Restarts the game by resetting game state and loading the initial level scene.
    /// </summary>
    public void RestartGame()
    {
        if (GameManagerInvadorsGame.Instance != null)
        {
            GameManagerInvadorsGame.Instance.ResetGame();
        }
        SceneManager.LoadScene("KingdomEntry"); 
    }
}


