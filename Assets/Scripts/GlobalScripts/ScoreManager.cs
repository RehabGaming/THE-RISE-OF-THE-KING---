using UnityEngine;

/// <summary>
/// Manages the scoring system for the game. 
/// Allows adding a predefined score value to the GameStats system.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int scoreToAdd; // The score value to add, set via the Inspector.

    /// <summary>
    /// Adds the predefined score value to the global GameStats system.
    /// </summary>
    public void AddScore()
    {
        Debug.Log("[AddScore] Adding score: " + scoreToAdd);
        GameStats.AddScore(scoreToAdd); // Adds the score to the global GameStats.
    }
}
