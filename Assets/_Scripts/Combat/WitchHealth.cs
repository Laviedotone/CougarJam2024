using UnityEngine;
using UnityEngine.SceneManagement;  // For scene loading

public class WitchHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

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
            SceneManager.LoadScene("WitchDead");
        }
    }
}
