using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public void RestarGame()
    {
        //FindObjectOfType<GameManager>().ResetPlayer();
        Application.LoadLevel("EndlessRuner");
    }

    public void QuitToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }
}
