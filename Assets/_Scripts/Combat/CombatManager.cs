using System.Collections;  // Required for IEnumerator and coroutines
using UnityEngine;
using UnityEngine.UI;  // For the turn UI elements
using UnityEngine.SceneManagement;  // For scene loading

public class CombatManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public WitchHealth witchHealth;
    public ParticleSystem witchAttackParticles;
    public float attackDuration = 5f;  // Duration of the witch attack
    public float moveSpeed = 5f;       // Speed at which the particle system moves back and forth
    public float moveRange = 5f;       // Distance between X positions (-5 to 5)

    public GameObject attackButton;
    public GameObject recoverButton;

    private bool playerTurn = true;  // Track whether it's the player's turn
    private bool isMoving = false;   // Track if the particle system is moving

    void Start()
    {
        // Set up button listeners
        attackButton.SetActive(true);
        recoverButton.SetActive(true);
        witchAttackParticles.Stop();  // Ensure the particles aren't playing at the start
    }

    void Update()
    {
        // If it's the player's turn, display action panel
        if (playerTurn)
        {
            attackButton.SetActive(true);
            recoverButton.SetActive(true);
        }
        else
        {
            attackButton.SetActive(false);
            recoverButton.SetActive(false);
        }
    }

    public void PlayerAttack()
    {
        witchHealth.TakeDamage(1);  // Player deals 1 damage
        playerTurn = false;  // End player turn
        StartCoroutine(WitchAttack());
    }

    public void PlayerRecover()
    {
        playerHealth.RecoverHealth(7);  // Recover 5 HP
        playerTurn = false;  // End player turn
        StartCoroutine(WitchAttack());
    }

    public void PlayerDied(){
        SceneManager.LoadScene("GameOver");
    }

    // Coroutine for Witch Attack
    IEnumerator WitchAttack()
    {
        // Start the particle system attack
        witchAttackParticles.Play();
        isMoving = true;  // Start moving the particle system

        float elapsedTime = 0f;
        
        // While the witch's attack is active, move the particle system back and forth
        while (elapsedTime < attackDuration)
        {
            // Move the particle system back and forth along the X-axis
            float xPosition = Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
            witchAttackParticles.transform.position = new Vector3(xPosition, witchAttackParticles.transform.position.y, witchAttackParticles.transform.position.z);

            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
        }

        // Stop the particle system attack
        
        witchAttackParticles.Stop();
        witchAttackParticles.Clear();
        isMoving = false;  // Stop the particle system movement

        // After the attack, switch back to player turn
        playerTurn = true;
    }
}
