using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Name of the main menu scene
    public string mainMenuLevel;

    // A reference to the pause menu
    public GameObject thePauseMenu;

    // A reference to the quit confirmation menu
    public GameObject theQuitConfirmationMenu;

    // A reference to the time manager
    public TimeManager theTimeManager;

    void Start()
    {
        // Here we set the time manager using FindObjectOfType, in this way Unity handle the search of the desired object
        // so we dont have to do it manually using the UI
        theTimeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {   
     
    }

    // Function that pauses the game
    public void PauseGame()
    {
        // Freeze the time of the game so it's paused
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
        theTimeManager.paused = true;
    }

    // Function that unpauses the game
    public void UnpauseGame()
    {
        // Unfreeze the time of the game so it's unpaused
        Time.timeScale = 1f;
        thePauseMenu.SetActive(false);
        theTimeManager.paused = false;
    }

    // Function that restarts the game
    public void RestarGame()
    {
        // Close the pause menu
        thePauseMenu.SetActive(false);

        // Set the time to 1 (normal)
        Time.timeScale = 1f;

        // Reset the player
        FindObjectOfType<GameManager>().ResetPlayer();
    }

    // Function that quits to the main menu
    public void QuitToMainMenu()
    {
        // Oppen the quit confirmation menu
        theQuitConfirmationMenu.SetActive(true);
    }
}
