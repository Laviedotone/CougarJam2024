using UnityEngine;
using TMPro;

public class InteractionTrigger : MonoBehaviour
{
    public DialogManager dialogManager;  // Reference to the DialogManager script
    public string potionMessage;  // The custom message for each potion

    private bool isPlayerInRange = false;  // Check if player is in trigger range

    // Detect when the player enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered the trigger area.");
        }
    }

    // Detect when the player exits the trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player exited the trigger area.");
        }
    }

    private void Update()
    {
        // Check if player is in range and presses Enter
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Player pressed Enter.");

            // Show the black screen with the potion message and trigger the gameplay
            dialogManager.ShowPotionExplanation(potionMessage);

            // Trigger the gameplay based on the potion chosen
            if (potionMessage.Contains("Red Potion"))
            {
                StartRedPotionGameplay();
            }
            else if (potionMessage.Contains("Green Potion"))
            {
                StartGreenPotionGameplay();
            }
            else if (potionMessage.Contains("Blue Potion"))
            {
                StartBluePotionGameplay();
            }
        }
    }

    void StartRedPotionGameplay()
    {
        Debug.Log("Starting Red Potion gameplay...");
        // Implement your Red Potion gameplay logic here
    }

    void StartGreenPotionGameplay()
    {
        Debug.Log("Starting Green Potion gameplay...");
        // Implement your Green Potion gameplay logic here
    }

    void StartBluePotionGameplay()
    {
        Debug.Log("Starting Blue Potion gameplay...");
        // Implement your Blue Potion gameplay logic here
    }
}
