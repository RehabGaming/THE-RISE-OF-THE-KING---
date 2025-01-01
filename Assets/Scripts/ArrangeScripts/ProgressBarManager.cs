using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the progress bar functionality in the game.
/// Updates the progress bar UI Image as progress increases
/// and notifies the GameLevelManager when the level is complete.
/// </summary>
public class ProgressBarManager : MonoBehaviour
{
    [Header("Progress Tracking")]
    [Tooltip("Tracks the current progress based on the number of items placed in the correct slots.")]
    [SerializeField] private int currentProgress;

    [Tooltip("The total number of items required to complete the level.")]
    [SerializeField] private int totalItems;

    [Header("Progress Bar UI")]
    [Tooltip("Array of sprites representing different progress stages.")]
    public Sprite[] progressBarStages;

    [Tooltip("The UI Image component that displays the current progress.")]
    public Image progressBarImage;

    [Header("References")]
    [SerializeField] private ScoreManager scoreManager;

    [Header("Audio Settings")]
    [Tooltip("Sound played when progress is updated.")]
    public AudioClip progressSound;

    [Tooltip("Sound played when the level is completed.")]
    public AudioClip levelEndSound;

    private AudioSource audioSource;
    private SceneManagement sceneManagement;

    private void Start()
    {
        // Add AudioSource if not already attached
        audioSource = gameObject.AddComponent<AudioSource>();
       // TimeTracker.TimeTrackingInstance.StartTracking();
    }

    /// <summary>
    /// Initializes the progress bar with the total number of items required for the level.
    /// </summary>
    /// <param name="itemsCount">Total items required for level completion.</param>
    public void InitializeProgressBar(int itemsCount)
    {           
        //totalItems = itemsCount;
        Debug.Log($"Initializing Progress Bar with {itemsCount} items.");
        UpdateProgressBar();
    }

    /// <summary>
    /// Adds progress when an item is successfully placed in the correct slot.
    /// </summary>
    public void AddProgress()
    {
        if (currentProgress < totalItems)
        {
            currentProgress++;
            UpdateProgressBar();
            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }
            else
            {
                Debug.LogWarning("ScoreManager is not assigned in ProgressBarManager!");
            }

            // Play progress sound
            if (progressSound != null && currentProgress < totalItems)
            {
                audioSource.PlayOneShot(progressSound);
            }
        }
        Debug.Log("Total items: " + totalItems + ". And Current Progress: " + currentProgress);
        // Check if the level is complete
        if (currentProgress == totalItems)
        {
            // Play level completion sound
            if (levelEndSound != null)
            {
                audioSource.PlayOneShot(levelEndSound);
            }
            else
            {
                Debug.Log("Audio source of End Level not found!");
            }

            Debug.Log("[ProgressBarManager] Level Complete!");

            // Notify SceneManagement to handle level completion
            if (SingletonManager.singltoneInstance != null && SingletonManager.singltoneInstance.sceneManagement != null)
            {
                SingletonManager.singltoneInstance.GetComponent<LevelUpManager>().ShowLevelUpScreen();

               //SingletonManager.singltoneInstance.sceneManagement.CompleteLevel();
            }
            else
            {
                Debug.LogError("[ProgressBarManager] LevelUpManager instance not found in SingletonManager!");
                Debug.LogError("[ProgressBarManager] SceneManagement or singltoneInstance instance not found!");
            }
        }
    }

    /// <summary>
    /// Updates the progress bar sprite to reflect the current progress.
    /// </summary>
    private void UpdateProgressBar()
    {
        if (progressBarStages.Length > 0 && progressBarImage != null)
        {
            int index = Mathf.Clamp(currentProgress, 0, progressBarStages.Length - 1);
            progressBarImage.sprite = progressBarStages[index];
        }
        else
        {
            Debug.LogWarning("Progress bar images are not properly set up.");
        }
    }
}
