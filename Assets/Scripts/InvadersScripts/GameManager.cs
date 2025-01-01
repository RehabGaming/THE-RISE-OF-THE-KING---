using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int lives = 3; // Number of lives for the player
    [SerializeField] private int liveCounter = 3;
    private int zero = 0; 
   

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

    public void LoseLife()
    {
        if (lives > zero)
        {
            lives--;
            LifeManager.Instance.UpdateHearts(lives); // Update hearts using LifeManager
        }

        if (lives <= zero)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        CharacterSpawner.Instance.StopSpawning(); // Stop spawning characters
        SceneManager.LoadScene("GameOverScene");
    }

    public void ResetGame()
    {
        lives = liveCounter;
        LifeManager.Instance.ResetHearts(); // Reset hearts using LifeManager
        TimerManager.Instance.ResetTimer(); // Reset timer using TimerManager
        CharacterSpawner.Instance.StartSpawning(); // Start spawning characters
    }
}
