using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float delayBeforeExit = 5f;  // Delay before closing the game

    void Start()
    {
        // Start the countdown to quit the game
        StartCoroutine(QuitGameAfterDelay());
    }

    // Coroutine that waits for the specified delay and then closes the game
    IEnumerator QuitGameAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeExit);

        // Close the game (works when built, will not work in the editor)
        Debug.Log("Game will close now.");
        Application.Quit();
    }
}
