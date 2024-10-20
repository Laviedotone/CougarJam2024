using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // For loading scenes
using UnityEngine.UI;  // If using UI elements

public class StartMenuBehavior : MonoBehaviour
{
    public GameObject Selection1;  // First button
    public GameObject Selection2;  // Second button

    private int pos = 0;  // Current position (0 for first button, 1 for second button)
    private bool keyPressed = false;

    void Start()
    {
        pos = 0;  // Start with the first option selected
        UpdateSelection();  // Update the selection visually
    }

    void Update()
    {
        // Handle navigation with the arrow keys or WASD
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (pos < 1)
            {
                pos++;
                UpdateSelection();  // Update the visual representation of the selection
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (pos > 0)
            {
                pos--;
                UpdateSelection();  // Update the visual representation of the selection
            }
        }

        // Handle the Enter key for selection
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ExecuteSelection();  // Perform the selected action
        }
    }

    // This function updates the visual representation of the selection
    void UpdateSelection()
    {
        // You can highlight the currently selected option by modifying the scale, color, or any other visual element
        if (pos == 0)
        {
            Selection1.SetActive(true);
            Selection2.SetActive(false);        // Reset Selection2
        }
        else if (pos == 1)
        {
            Selection2.SetActive(true);
            Selection1.SetActive(false);        // Reset Selection2
        }
    }

    // This function executes the selected action
    void ExecuteSelection()
    {
        if (pos == 0)
        {
            // Load the CombatScene
            SceneManager.LoadScene("CombatScene");
        }
        else if (pos == 1)
        {
            // Quit the game
            Debug.Log("Quitting Game...");
            Application.Quit();
        }
    }
}
