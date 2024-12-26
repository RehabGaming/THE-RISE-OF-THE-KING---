using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles transitioning to the next scene after the portal effect is completed.
/// </summary>
public class NextScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // The name of the scene to load
    [SerializeField] private float delayBeforeTransition; // Delay (in seconds) before loading the scene

    /// <summary>
    /// Initiates the scene transition after a specified delay.
    /// </summary>
    public void TransitionToScene()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    /// <summary>
    /// Coroutine to load the scene after a delay.
    /// </summary>
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeTransition);
        Debug.Log("Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
