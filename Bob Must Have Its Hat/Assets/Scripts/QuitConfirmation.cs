using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitConfirmation : MonoBehaviour
{
    public string mainMenuLevel;

    public GameObject theConfirmationQuitMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") || Input.GetKey("Q") || Input.GetKey("m") || Input.GetKey("M"))
        {
            ConfirmQuitToMainMenu();
        }

        if (Input.GetKey("n") || Input.GetKey("N") || Input.GetKeyDown(KeyCode.Escape))
        {
            NotQuitToMainMenu();
        }
    }

    public void ConfirmQuitToMainMenu()
    {
        theConfirmationQuitMenu.SetActive(true);

        Time.timeScale = 1f;
        Application.LoadLevel("Main Menu");
    }

    public void NotQuitToMainMenu()
    {
        theConfirmationQuitMenu.SetActive(false);
    }
}
