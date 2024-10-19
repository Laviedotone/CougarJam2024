using UnityEngine;

public class WitchProjectile : MonoBehaviour
{
    public float speed = 2f;  // Slower speed of the projectile (adjust to make it visible)
    public int damage = 3;    // Damage the projectile will deal to the player
    public string sortingLayer = "Foreground";  // Sorting layer to ensure visibility
    public int sortingOrder = 1;  // Sorting order for rendering

    private Vector2 moveDirection;
    private Vector2 previousPosition;

    // Initialize the projectile's movement and ensure it's visible
    public void Initialize(Vector2 direction)
    {
        moveDirection = direction.normalized;

        // Save the initial position for drawing the line
        previousPosition = transform.position;

        // Set sorting layer and order if the projectile has a SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingLayerName = sortingLayer;
            spriteRenderer.sortingOrder = sortingOrder;
        }

        // Ensure the Z position is correct (for 2D games)
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);  // Set Z to 0
    }

    void Update()
    {
        // Move the projectile
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Draw a line in the editor to visualize the projectile's movement
        Debug.DrawLine(previousPosition, transform.position, Color.red, 0.2f);  // Line lasts for 0.2 seconds

        // Update the previous position for the next frame
        previousPosition = transform.position;

        // Destroy the projectile after 10 seconds
        Destroy(gameObject, 10f);
    }

    // Detect collision with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);  // Destroy the projectile after hitting the player
        }
    }
}
