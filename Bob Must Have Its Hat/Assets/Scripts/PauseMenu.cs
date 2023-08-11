using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public GameObject thePauseMenu;

    public GameObject theQuitConfirmationMenu;

    public TimeManager theTimeManager;

    void Start()
    {
        theTimeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("p"))
        {
            //EventSystem.current.SetSelectedGameObject(this.gameObject);
            PauseGame();
        }
        */
        
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            theTimeManager.paused = true;
            PauseGame();
        }
        
        if (Time.timeScale <= 0 && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)))
        {
            theTimeManager.paused = false;
            UnpauseGame();
        }
        
        if (Input.GetKey("r") || Input.GetKey("R"))
        {
            RestarGame();
        }

        if (Input.GetKey("q") || Input.GetKey("Q") || Input.GetKey("m") || Input.GetKey("M"))
        {
            QuitToMainMenu();
        }
    }

    public void PauseGame()
    {
        // Freeze the time of the game
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
        theTimeManager.paused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        thePauseMenu.SetActive(false);
        theTimeManager.paused = false;
    }

    public void RestarGame()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().ResetPlayer();
    }

    public void QuitToMainMenu()
    {
        theQuitConfirmationMenu.SetActive(true);
        /*
        Time.timeScale = 1f;
        Application.LoadLevel("Main Menu");
        */
    }
}
