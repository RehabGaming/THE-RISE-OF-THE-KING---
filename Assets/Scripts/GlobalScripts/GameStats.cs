using UnityEngine;

/// <summary>
/// A static class for managing game-wide statistics, such as the current score and total time.
/// Tracks and resets statistics globally throughout the game.
/// </summary>
public static class GameStats
{
    /// <summary>
    /// The player's current score. Initially set to 0.
    /// </summary>
    public static int CurrentScore { get; private set; } = 0;

    /// <summary>
    /// The total time tracked during gameplay. Initially set to 0.
    /// </summary>
    public static float TotalTime { get; private set; } = 0f;

    /// <summary>
    /// Adds the specified score to the player's current score.
    /// </summary>
    /// <param name="scoreToAdd">The score value to add.</param>
    public static void AddScore(int scoreToAdd)
    {
        CurrentScore += scoreToAdd;
        Debug.Log($"[GameStats] Score added: {scoreToAdd}. Current Score: {CurrentScore}");
    }

    /// <summary>
    /// Adds the specified time to the total gameplay time.
    /// </summary>
    /// <param name="time">The time value to add in seconds.</param>
    public static void AddTime(float time)
    {
        TotalTime += time;
        Debug.Log($"[GameStats] Time added: {time} seconds. Total Time: {TotalTime} seconds");
    }

    /// <summary>
    /// Resets the player's score and total time to their initial values.
    /// </summary>
    public static void ResetStats()
    {
        CurrentScore = 0;
        TotalTime = 0f;
        Debug.Log("[GameStats] Stats have been reset.");
    }
}
