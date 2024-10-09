using UnityEngine;

public class ExitTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player's hand or the object intended to interact with the button
        if (other.CompareTag("PlayerHand")) // Replace "PlayerHand" with the tag used for the player's hand object
        {
            ExitApp();
        }
    }

    public void ExitApp()
    {
        Debug.Log("Exiting application...");
        Application.Quit();
    }
}
