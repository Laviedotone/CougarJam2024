using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public WitchHealth witchHealth;
    public int damage = 3;  // Damage per particle hit

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                if(witchHealth.currentHealth <= 3){
                    playerHealth.TakeDamage(damage+2);
                }else{
                    playerHealth.TakeDamage(damage);
                }
                
            }
        }
    }
}
