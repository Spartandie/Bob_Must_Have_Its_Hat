using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitConfirmation : MonoBehaviour
{
    // The name of the Menu Scene
    public string mainMenuLevel;

    // The confirmation quit menu Game Object
    public GameObject theConfirmationQuitMenu;

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function that asks the player if w¿he wants to quit to the main manu
    public void ConfirmQuitToMainMenu()
    {
        // Activate the confirmation quit menu Game Object
        theConfirmationQuitMenu.SetActive(true);

        // Set the time scale to 1 (normal)
        Time.timeScale = 1f;

        // Quit to the main menu
        Application.LoadLevel("Main Menu");
    }

    // Function that aborts the quit to main menu operation
    public void NotQuitToMainMenu()
    {
        // Deactivate the confirmation quit menu Game Object
        theConfirmationQuitMenu.SetActive(false);
    }
}
