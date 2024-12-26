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
    public int currentProgress;

    [Tooltip("The total number of items required to complete the level.")]
    public int totalItems;

    [Header("Progress Bar UI")]
    [Tooltip("Array of sprites representing different progress stages.")]
    public Sprite[] progressBarStages;

    [Tooltip("The UI Image component that displays the current progress.")]
    public Image progressBarImage;

    [Header("Audio Settings")]
    [Tooltip("Sound played when progress is updated.")]
    public AudioClip progressSound;

    [Tooltip("Sound played when the level is completed.")]
    public AudioClip levelEndSound;

    private AudioSource audioSource;

    private void Start()
    {
        // Add AudioSource if not already attached
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// Initializes the progress bar with the total number of items required for the level.
    /// </summary>
    /// <param name="itemsCount">Total items required for level completion.</param>
    public void InitializeProgressBar(int itemsCount)
    {

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

            // Play progress sound
            if (progressSound != null && currentProgress < totalItems)
            {
                audioSource.PlayOneShot(progressSound);
            }
        }
        Debug.Log("Total items: " + totalItems + ". And Current Progress: " + currentProgress);
        // Check if the level is complete
        if (currentProgress == totalItems && levelEndSound != null)
        {
            audioSource.PlayOneShot(levelEndSound);
            Debug.Log("Level Complete!");

            // Call the CompleteLevel function
            if (SingletonManager.Instance != null && SingletonManager.Instance.sceneManagement != null)
            {
                SingletonManager.Instance.sceneManagement.CompleteLevel();
            }
            else
            {
                Debug.LogError("SingletonManager or SceneManagement instance is not found!");
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
