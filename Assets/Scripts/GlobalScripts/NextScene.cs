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

    public void TransitionToScene() => StartCoroutine(LoadSceneAfterDelay());

    /// <summary>
    /// Coroutine to load the scene after a delay.
    /// </summary>
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeTransition);
        // Log the scene transition
        if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            Debug.Log("[NextScene] Loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log("[NextScene] Trying to load scene: " + sceneToLoad);
            Debug.Log("[NextScene] Checking all scenes in Build Settings...");
            for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
                Debug.Log("Scene in Build Settings [" + i + "]: " + sceneName);
            }
            Debug.LogError("[NextScene] Scene '" + sceneToLoad + "' cannot be loaded. Check Build Settings or the scene name.");
        }
    }
}
