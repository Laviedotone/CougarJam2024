using UnityEngine;

public class WitchHealth : MonoBehaviour
{
    public int maxHealth = 8;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Handle witch defeat here
            Debug.Log("Witch Defeated!");
        }
    }
}
