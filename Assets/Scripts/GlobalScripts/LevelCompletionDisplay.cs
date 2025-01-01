// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// /// <summary>
// /// Displays the level completion UI and waits for player input to proceed.
// /// </summary>
// public class LevelCompletionDisplay : MonoBehaviour
// {
//     [Tooltip("The UI GameObject to display upon level completion.")]
//     public GameObject completionUI;

//     [Tooltip("The TMP_Text object to display the final score.")]
//     public TMP_Text  finalScoreText;

//  /// <summary>
//     /// Displays the level completion UI and shows the final score.
//     /// </summary
//     public void ShowCompletionUI()
//     {
//         if (completionUI != null)
//         {
//             completionUI.SetActive(true); // Show the completion UI
//             Time.timeScale = 0; // Pause the game while waiting for player input
//           // Update the final score text
//             if (finalScoreText != null && ScoringManager.ScoringInstance != null)
//             {
//                 finalScoreText.text = $"Final Score: {ScoringManager.ScoringInstance.totalScore}";
//             }
          
//             Debug.Log("[LevelCompletionDisplay] Level completion UI displayed.");
//         }
//         else
//         {
//             Debug.LogError("[LevelCompletionDisplay] Completion UI not assigned.");
//         }
//     }

//     /// <summary>
//     /// Hides the level completion UI and resumes the game.
//     /// </summary>
//     public void HideCompletionUI()
//     {
//         if (completionUI != null)
//         {
//             completionUI.SetActive(false); // Hide the completion UI
//             Time.timeScale = 1; // Resume the game
//             Debug.Log("[LevelCompletionDisplay] Level completion UI hidden.");
//         }
//     }
// }
