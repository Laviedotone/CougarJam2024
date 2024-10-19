using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;  // For scene loading

public class PotionSelector : MonoBehaviour
{
    public DialogManager dialogManager;  // Reference to the DialogManager script
    public PlayerMovement playerMovement;  // Reference to PlayerMovement to disable player movement
    public float delayBeforeSceneChange = 8f;  // 15 seconds delay before changing scene

    public enum PotionType { Red, Green, Blue }
    private PotionType selectedPotion;

    // Custom messages for each potion
    public string redPotionMessage = "You drink the Red Potion. The potion strengthens your combat ability, making you face the Witch head on.";
    public string greenPotionMessage = "You drink the Green Potion. Memories flood your mind, and you must use your past to solve puzzles.";
    public string bluePotionMessage = "You drink the Blue Potion. Curiosity drives you to explore the tower, and you begin to climb to the top.";

    // Method to choose a potion
    public void ChoosePotion(PotionType potionType)
    {
        selectedPotion = potionType;

        // Disable player movement
        playerMovement.enabled = false;

        // Show the black screen and display the explanation, then wait 15 seconds before scene change
        StartCoroutine(DisplayPotionExplanationAndChangeScene(potionType));
    }

    // Coroutine to display the potion explanation and then wait before changing the scene
    IEnumerator DisplayPotionExplanationAndChangeScene(PotionType potionType)
    {
        switch (potionType)
        {
            case PotionType.Red:
                dialogManager.ShowPotionExplanation(redPotionMessage);
                yield return new WaitForSeconds(delayBeforeSceneChange);  // Wait 15 seconds
                SceneManager.LoadScene("CombatScene");
                break;
            case PotionType.Green:
                dialogManager.ShowPotionExplanation(greenPotionMessage);
                yield return new WaitForSeconds(delayBeforeSceneChange);  // Wait 15 seconds
                // SceneManager.LoadScene("PuzzleScene");
                SceneManager.LoadScene("GameOver");
                break;
            case PotionType.Blue:
                dialogManager.ShowPotionExplanation(bluePotionMessage);
                yield return new WaitForSeconds(delayBeforeSceneChange);  // Wait 15 seconds
                // SceneManager.LoadScene("PlatformingScene");
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
}
