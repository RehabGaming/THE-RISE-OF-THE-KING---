using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the Level-Up screen, including displaying the player's score,
/// transitioning to the next level, and quitting the game.
/// </summary>
public class LevelUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpPic; // The Level-Up UI panel that appears between levels.

    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText; // UI element to display the player's score.

    [SerializeField]
    private Button continueButton; // Button to proceed to the next level.

    [SerializeField]
    private Button quitButton; // Button to quit the game.

    /// <summary>
    /// Initializes the Level-Up UI, disabling it at the start and adding listeners to the buttons.
    /// </summary>
    private void Start()
    {
        levelUpPic.SetActive(false); // Ensure the Level-Up screen is hidden initially.
        continueButton.onClick.AddListener(ContinueToNextLevel); // Add listener to "Continue" button.
        quitButton.onClick.AddListener(QuitGame); // Add listener to "Quit" button.
    }

    /// <summary>
    /// Displays the Level-Up screen with the player's current score and moves it to the active canvas.
    /// </summary>
    public void ShowLevelUpScreen()
    {
        scoreText.text = $"Score: {GameStats.CurrentScore}"; // Update the score text.
        MoveToCurrentCanvas(); // Ensure the Level-Up UI is on the correct canvas.
        levelUpPic.SetActive(true); // Display the Level-Up screen.
    }

    /// <summary>
    /// Moves the Level-Up UI to the current active canvas in the scene.
    /// </summary>
    private void MoveToCurrentCanvas()
    {
        GameObject canvasObject = GameObject.FindWithTag("MainCanvas"); // Find the main canvas by tag.
        if (canvasObject != null)
        {
            Canvas canvas = canvasObject.GetComponent<Canvas>();
            if (canvas != null)
            {
                levelUpPic.transform.SetParent(canvas.transform, false); // Attach the Level-Up UI to the canvas.
            }
        }
        else
        {
            Debug.LogError("No Canvas with the tag 'MainCanvas' found in the current scene!");
        }
    }

    /// <summary>
    /// Proceeds to the next level, hiding the Level-Up screen and updating its parent to the singleton.
    /// </summary>
    private void ContinueToNextLevel()
    {
        levelUpPic.SetActive(false); // Hide the Level-Up screen.
        if (levelUpPic != null)
        {
            levelUpPic.transform.SetParent(SingletonManager.singltoneInstance.transform, false); // Reset parent.
            levelUpPic.SetActive(false);
        }
        SingletonManager.singltoneInstance.sceneManagement.CompleteLevel(); // Transition to the next level.
    }

    /// <summary>
    /// Exits the game application.
    /// </summary>
    private void QuitGame() => Application.Quit();
}
