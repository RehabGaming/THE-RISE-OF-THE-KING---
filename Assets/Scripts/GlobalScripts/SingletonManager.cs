using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the singleton instance of GameManager.
/// </summary>
public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Instance { get; private set; }

    public string managedSceneName;

    public SceneManagement sceneManagement;
    public ExplanationManager explanationManager;

    [Header("Managed Scenes")]
    [Tooltip("Scenes that this GameManager will manage.")]
    public string[] managedScenes;

    /// <summary>
    /// Ensures a single instance and initializes components when awake.
    private void Awake()
    {
        Debug.Log("Current scene: " + SceneManager.GetActiveScene().name + ", Managed scene: " + managedSceneName);

        if (managedSceneName == SceneManager.GetActiveScene().name)
        {
            if (Instance != null && Instance != this)
            {
                Debug.Log("Destroying old GameManager instance for new scene-specific instance.");
                Destroy(Instance.gameObject);
            }
            else
            {
                Debug.Log("No existing instance found or current instance is the singleton. Setting as Singleton.");
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager set as DontDestroyOnLoad for " + managedSceneName);
            // Initialize other components
            InitializeComponents();
        }
        else
        {
            Debug.Log("This GameManager is not for this scene, destroying.");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Initializes necessary components for scene and explanation management.
    private void InitializeComponents()
    {
        // Assuming that these components are attached to the same GameObject as the SingletonManager
        sceneManagement = GetComponent<SceneManagement>();
        explanationManager = GetComponent<ExplanationManager>();

        // If they are not found, instantiate them or log an error
        if (sceneManagement == null)
        {
            sceneManagement = gameObject.AddComponent<SceneManagement>();
        }
        if (explanationManager == null)
        {
            explanationManager = gameObject.AddComponent<ExplanationManager>();
        }
    }
}
