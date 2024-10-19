using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject blackScreenPanel;  // Reference to the UI Panel (Black Screen)
    public TextMeshProUGUI messageText;  // The UI Text component for displaying dialog
    public float letterDelay = 0.05f;    // Delay between each letter

    void Start()
    {
        // Hide the black screen at the start of the game
        blackScreenPanel.SetActive(false);
    }

    // Method to show the black screen and start displaying the text letter by letter
    public void ShowPotionExplanation(string dialogMessage)
    {
        if (blackScreenPanel == null || messageText == null)
        {
            Debug.LogError("BlackScreenPanel or MessageText is not assigned.");
            return;
        }

        // Make the black screen fully opaque and active
        CanvasGroup canvasGroup = blackScreenPanel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;  // Set opacity to 1 (fully opaque)
        }

        blackScreenPanel.SetActive(true);
        StartCoroutine(DisplayTextLetterByLetter(dialogMessage));
    }

    // Coroutine to display text letter by letter on the black screen
    IEnumerator DisplayTextLetterByLetter(string text)
    {
        messageText.text = "";  // Start with an empty string

        foreach (char letter in text.ToCharArray())
        {
            messageText.text += letter;  // Add one letter at a time
            yield return new WaitForSeconds(letterDelay );  // Wait before adding the next letter
        }
    }

    // Method to hide the black screen (if needed later)
    public void HideBlackScreen()
    {
        blackScreenPanel.SetActive(false);
    }
}
