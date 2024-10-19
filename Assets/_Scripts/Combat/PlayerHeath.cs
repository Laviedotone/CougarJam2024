using UnityEngine;
using TMPro;  // For updating health text UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public TextMeshProUGUI healthText;  // Link to a TextMeshProUGUI for health display

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Handle player death here
            Debug.Log("Player Died!");
        }
        UpdateHealthUI();  // Update the health text when the player takes damage
    }

    public void RecoverHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();  // Update the health text when the player heals
    }

    // Method to update the health text UI
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth.ToString() + "/" + maxHealth.ToString();
        }
        else
        {
            Debug.LogError("Health Text is not assigned in the Inspector!");
        }
    }
}
