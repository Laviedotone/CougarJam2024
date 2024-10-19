using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 3;  // Damage per particle hit

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
