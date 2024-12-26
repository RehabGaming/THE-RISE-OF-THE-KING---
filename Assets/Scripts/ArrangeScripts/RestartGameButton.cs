using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    //The name of the string to be Restarted
    [SerializeField] private string SceneToRestart;

    // Public method to restart the game by reloading the scene.
    public void Restart()
    {
        if (string.IsNullOrEmpty(SceneToRestart))
        {
            Debug.LogError("SceneToRestart is not set in the Inspector.");
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(SceneToRestart))
        {
            Debug.LogError($"Scene '{SceneToRestart}' cannot be loaded. Check if it's added to Build Settings.");
            return;
        }

        SceneManager.LoadScene(SceneToRestart);
    }

}
