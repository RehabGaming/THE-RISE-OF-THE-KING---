using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages game states, character spawning, and timer for Invadors Game.
/// </summary>
public class GameManagerInvadorsGame : MonoBehaviour
{
    public static GameManagerInvadorsGame Instance;
    public GameObject[] characters;
    public Transform spawnPoint;
    public float spawnInterval;
    public int lives;
    public Image[] hearts;
    public TextMeshProUGUI timerText;
    public float levelTime;
    private float currentTime;

    /// <summary>
    /// Initializes the singleton instance and sets it to not be destroyed on load.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts the character spawning cycle and initializes the timer.
    /// </summary>
    private void Start()
    {
        currentTime = levelTime;
        InvokeRepeating(nameof(SpawnCharacter), 0f, spawnInterval);
    }

    /// <summary>
    /// Updates the game timer each frame.
    /// </summary>
    private void Update()
    {
        HandleTimer();
    }

    /// <summary>
    /// Spawns a character at a designated spawn point.
    /// </summary>
    private void SpawnCharacter()
    {
        int index = Random.Range(0, characters.Length);
        Vector3 spawnPos = new Vector3(0, spawnPoint.position.y, 0);
        Instantiate(characters[index], spawnPos, Quaternion.identity);
    }

    /// <summary>
    /// Decreases the player's lives and updates the UI.
    /// </summary>
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            hearts[lives].enabled = false;
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }
    /// <summary>
    /// Handles the countdown timer and triggers level completion when time expires.
    /// </summary>
    private void HandleTimer()
    {
        if (timerText == null)
        {
            Debug.LogError("timerText is not assigned.");
            return;
        }

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
        }
        else
        {
            currentTime = 0;
            LevelComplete();
        }
    }

    /// <summary>
    /// Completes the current level and handles the transition based on remaining lives.
    /// </summary>
    private void LevelComplete()
    {
        CancelInvoke(nameof(SpawnCharacter));
        if (lives > 0)
        {
            SceneManager.LoadScene("SecondLevelScene");
        }
        else
        {
            GameOver();
        }
    }

    /// <summary>
    /// Ends the game and loads the game over scene.
    /// </summary>
    private void GameOver()
    {
        Debug.Log("Game Over!");
        CancelInvoke(nameof(SpawnCharacter));

        // Ensure this game manager is destroyed before loading a new scene
        Destroy(gameObject);

        // Load the game over scene
        SceneManager.LoadScene("GameOverScene1");
    }

    /// <summary>
    /// Resets the game to its initial state.
    /// </summary>
    public void ResetGame()
    {
        lives = 3;
        currentTime = levelTime;
        foreach (Image heart in hearts)
        {
            heart.enabled = true;
        }

        InvokeRepeating(nameof(SpawnCharacter), 0f, spawnInterval);
    }
}
