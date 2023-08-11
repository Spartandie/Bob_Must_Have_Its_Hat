using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    // The name of the main menu
    public string mainMenuLevel;

    // Function that restarts the game
    public void RestarGame()
    {
        // Load the game scene
        Application.LoadLevel("EndlessRuner");
    }

    // Function that quits to the main menu
    public void QuitToMainMenu()
    {
        // Load the main menu scene
        Application.LoadLevel("Main Menu");
    }
}
