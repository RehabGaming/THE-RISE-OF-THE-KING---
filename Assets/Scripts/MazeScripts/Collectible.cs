using UnityEngine;
//using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class Collectible : MonoBehaviour
{
  //  Script to handle item collection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Directly call itemsScript to handle item collection
            FindFirstObjectByType<itemsScript>().CollectItem();
            Destroy(gameObject);  // Remove item from the scene
        }
    }
}
