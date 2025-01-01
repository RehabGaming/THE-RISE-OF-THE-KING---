using UnityEngine;
using TMPro; // TextMeshPro for displaying the timer
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance; // Singleton instance of the TimerManager
    [SerializeField] private TextMeshProUGUI timerText; // UI element for displaying the timer
    [SerializeField] private float levelTime = 30f; // Total level time in seconds
    private float currentTime; // Current countdown time
    private int zero = 0; // Constant for zero to avoid magic numbers

    private void Awake()
    {
        // Ensure only one instance of TimerManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate TimerManager objects
        }
    }

    private void Start()
    {
        ResetTimer(); // Initialize the timer at the start of the level
    }

    private void Update()
    {
        HandleTimer(); // Update the timer every frame
    }

    private void HandleTimer()
    {
        // If there is remaining time, decrement it and update the display
        if (currentTime > zero)
        {
            currentTime -= Time.deltaTime; // Reduce the time by the elapsed frame time
            timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString(); // Update the timer UI
        }
        else
        {
            // If time reaches zero, complete the level
            currentTime = zero;
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        // Stop spawning characters when the level is complete
        CharacterSpawner.Instance.StopSpawning();

        // If the player has remaining lives, load the next level
        if (GameManager.Instance.lives > zero)
        {
            SceneManager.LoadScene("SecondLevelScene");
        }
        else
        {
            // If no lives are left, reset the game
            GameManager.Instance.ResetGame();
        }
    }

    public void ResetTimer()
    {
        // Reset the timer to the total level time
        currentTime = levelTime;
    }
}
