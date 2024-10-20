using System.Collections;
using UnityEngine;
using TMPro;  // For updating health text UI
using UnityEngine.SceneManagement;  // For scene loading

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public TextMeshProUGUI healthText;  // Link to a TextMeshProUGUI for health display
    public float iFrameDuration = 1f;  // Duration of invincibility after being hit
    private bool isInvincible = false;  // Track if the player is currently invincible
    public SpriteRenderer spriteRenderer;  // Reference to the player's sprite renderer (for flashing effect)


    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                // Trigger game over or death logic
                Debug.Log("Player Died!");
                SceneManager.LoadScene("GameOver");
            }
            UpdateHealthUI();
            StartCoroutine(StartInvincibility());
        }
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

private IEnumerator StartInvincibility()
    {
        isInvincible = true;

        // Flash effect (optional)
        float elapsedTime = 0f;
        bool isVisible = true;
        while (elapsedTime < iFrameDuration)
        {
            spriteRenderer.enabled = isVisible;
            isVisible = !isVisible;
            elapsedTime += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        // Make sure the sprite is visible after the flash
        spriteRenderer.enabled = true;
        isInvincible = false;
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
