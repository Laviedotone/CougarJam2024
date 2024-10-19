using UnityEngine;
using TMPro;

public class PotionSelectionTrigger : MonoBehaviour
{
    public GameObject textBoxPanel;  // Reference to the UI Panel (Text Box)
    public TextMeshProUGUI messageText;   // The UI Text component for displaying dialog
    public string potionMessage;  // The message to display when triggered
    public PotionSelector potionSelector;

    private bool isPlayerInRange = false;

    void Start()
    {
        // Hide the text box at the start of the game
        textBoxPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            ShowMessage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            textBoxPanel.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player is in range and presses Enter
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Return))
        {
            StartGameplay();
        }
    }

    void ShowMessage()
    {
        textBoxPanel.SetActive(true);
        messageText.text = potionMessage;
        messageText.ForceMeshUpdate();
    }

    void StartGameplay()
    {
        textBoxPanel.SetActive(false);  // Hide dialog after the player makes a choice

        if (potionMessage == "Red Potion: Confidence to Fight")
        {
            StartRedPotionGameplay();
        }
        else if (potionMessage == "Green Potion: Flashbacks to Solve Puzzles")
        {
            StartGreenPotionGameplay();
        }
        else if (potionMessage == "Blue Potion: Curiosity for Platforming")
        {
            StartBluePotionGameplay();
        }
    }

    void StartRedPotionGameplay()
    {
        // Add logic to start the Red potion gameplay
        Debug.Log("Starting Red Potion gameplay...");
        potionSelector.ChoosePotion(PotionSelector.PotionType.Red);
        // You can enable combat mechanics or change the player's behavior here
    }

    void StartGreenPotionGameplay()
    {
        // Add logic to start the Green potion gameplay
        Debug.Log("Starting Green Potion gameplay...");
        potionSelector.ChoosePotion(PotionSelector.PotionType.Green);
        // You can enable puzzle-solving mechanics or flashback sequences here
    }

    void StartBluePotionGameplay()
    {
        // Add logic to start the Blue potion gameplay
        Debug.Log("Starting Blue Potion gameplay...");
        potionSelector.ChoosePotion(PotionSelector.PotionType.Blue);
        // You can enable platforming mechanics or new levels here
    }
}
