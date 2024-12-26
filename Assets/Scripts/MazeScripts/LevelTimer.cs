using UnityEngine;
using TMPro; // Using TextMeshPro for UI text rendering.

/// <summary>
/// Manages a countdown timer for levels in the game.
/// </summary>
public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; // The display field for the timer.
    public float timeLimit; // The total time allowed for the level.

    private float timeRemaining; // Tracks the remaining time.

    /// <summary>
    /// Initializes the timer with the full time limit at the start of the level.
    /// </summary>
    private void Start()
    {
        timeRemaining = timeLimit; // Initialize the remaining time.
    }

    /// <summary>
    /// Updates the countdown each frame and updates the UI text.
    /// </summary>
    private void Update()
    {
        if (timeRemaining > 0)
        {
            // Decrease the remaining time
            timeRemaining -= Time.deltaTime;

            // Update the timer display on the UI
            timerText.text = "Time Left: " + Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            // Handle what happens when the timer runs out
            Debug.Log("Time's up!"); // Log that the time has expired.
        }
    }
}
