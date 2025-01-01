using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    // This method is triggered when another collider enters the trigger area of this object.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player by comparing tags
        if (other.CompareTag("Player"))
        {
            // Find the item manager in the scene to check item collection status
            var itemManager = FindFirstObjectByType<itemsScript>();

            // Ensure the item manager is found and check if all items have been collected
            if (itemManager != null && itemManager.AllItemsCollected())
            {
                // If all items are collected, print that the maze is completed
                Debug.Log("Maze Completed!");

                // trigger the WinGame() method to load the win scene
                // WinGame(); 
            }
            else
            {
                // Calculate how many more items the player needs to collect to exit
                int remainingItems = itemManager.totalItems - itemManager.collectedItems;

                // print remaining items to inform the player that they need to collect more
                Debug.Log("Collect " + remainingItems + " more item(s) to unlock the exit!");
            }
        }
    }

    // This method can be used to load the win scene when the player completes the maze
    private void WinGame()
    {
        // Load the "WinScene" after the maze is completed
        SceneManager.LoadScene("VictoryScene");  
    }
}
