using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages scene transitions and level loading.
/// </summary>
public class SceneManagement : MonoBehaviour
{
    //to add when i will create levels
    // [Header("Level Settings")]
    // [Tooltip("The default starting level (e.g., Level 1).")]
    // public string defaultLevelName;
    [Header("Scene Management")]
    [Tooltip("Names of the levels to load based on selection or button click.")]
    public string[] levelNames;

    [Header("Level Completion Settings")]
    [Tooltip("Time to wait (in seconds) before transitioning to the next level.")]
    [SerializeField]
    private float levelTransitionDelay;

    [Tooltip("The Intro screen scene name to load after skipping or finishing the explanation.")]
    public string introSceneName;

    /// <summary>
    /// Subscribes to the sceneLoaded event when the object is enabled.
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    /// <summary>
    /// Unsubscribes from the sceneLoaded event when the object is disabled.
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    /// <summary>
    /// Handles actions after a scene is loaded, particularly updating explanation slides.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene loaded: {scene.name}");
        if (scene.name == introSceneName && SingletonManager.Instance.explanationManager != null)
        {
            SingletonManager.Instance.explanationManager.UpdateExplanationSlides();
        }
        else if (SingletonManager.Instance.explanationManager == null)
        {
            Debug.LogError("ExplanationManager is not assigned or has been destroyed.");
        }
    }

    /// <summary>
    /// Initiates the loading of a level by index.
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelNames.Length)
        {
            string levelName = levelNames[levelIndex];
            if (!string.IsNullOrEmpty(levelName))
            {
                Debug.Log($"Loading level: {levelName}");
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogError("Level name is not defined in the array!");
            }
        }
        else
        {
            Debug.LogError("Level index is out of range!");
        }
    }

    /// <summary>
    /// Marks the current level as complete and transitions to the next level.
    public void CompleteLevel()
    {
        int nextLevelIndex = 0;

        // Determine the index of the current level and calculate the next level index
        for (int i = 0; i < levelNames.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == levelNames[i])
            {
                nextLevelIndex = i + 1;
                break;
            }
        }

        // Load the next level if index is valid
        if (nextLevelIndex >= 0 && nextLevelIndex < levelNames.Length)
        {
            Debug.Log($"Level complete. Transitioning to next level: {levelNames[nextLevelIndex]} in {levelTransitionDelay} seconds.");
            StartCoroutine(TransitionToNextLevel(nextLevelIndex));
        }
        else
        {
            Debug.LogError("No next level found or end of levels reached.");
        }
    }

    /// <summary>
    /// Manages the time delay before loading the next level.
    private IEnumerator TransitionToNextLevel(int levelIndex)
    {
        yield return new WaitForSeconds(levelTransitionDelay);
        SceneManager.LoadScene(levelNames[levelIndex]);
    }
}
