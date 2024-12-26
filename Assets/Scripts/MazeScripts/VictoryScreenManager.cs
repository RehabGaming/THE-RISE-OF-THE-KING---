using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the victory screen interactions, specifically transitioning to the main scene.
/// </summary>
public class VictoryScreenManager : MonoBehaviour
{
    /// <summary>
    /// Loads the main game scene when called.
    /// </summary>
    public void LoadMainScene()
    {
        // Load the scene that represents the main or first level of the game
        SceneManager.LoadScene("FirstLevelScene");
    }
}
