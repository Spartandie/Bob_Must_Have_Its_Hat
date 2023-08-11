using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Reference to the position of the platform generator
    public Transform platformGenerator;
    public Vector3 platformStartPoint;

    // Reference to the player
    public PlayerController thePlayer;

    // Starting point of the player
    private Vector3 playerStartPoint;

    // Start speed of the player
    public float startSpeed;

    // Reference to the bob
    public BobController theBob;

    // Starting point of the bob
    private Vector3 bobStartPoint;

    // Array of ground
    private GroundDestroyer[] groundList;

    // Reference to the score manager
    private ScoreManager theScoreManager;

    // Reference to the death menu
    public DeathMenu theDeadthMenu;

    // The name of the death scene
    public string theDeathScene;

    // Reference to the pause button
    public PauseMenu thePauseButton;

    public bool powerupReset;

    // Start is called before the first frame update
    void Start()
    {
        // Set the position of the platform start point
        platformStartPoint = platformGenerator.position;

        // Set the player start point
        playerStartPoint = thePlayer.transform.position;

        // Here we set the score manager using FindObjectOfType, in this way Unity handle the search of the desired object
        // so we dont have to do it manually using the UI
        theScoreManager = FindObjectOfType<ScoreManager>();

        // Set the player move speed
        thePlayer.moveSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function that restarts the game
    public void RestartGame()
    {
        // Stop increasing the score
        theScoreManager.scoreIncreasing = false;

        // Deactivate the player obj to restart it
        thePlayer.gameObject.SetActive(false);

        // Save the score and coins of the payer
        PlayerPrefs.SetFloat("CurrentScore", theScoreManager.scoreCounter);
        PlayerPrefs.SetInt("Coins", theScoreManager.coinsCounter);

        // Activate the game menu
        theDeadthMenu.gameObject.SetActive(true);

        // Change the scene to the death scene
        Application.LoadLevel(theDeathScene);
    }

    // Function that resets the player
    public void ResetPlayer()
    {
        // Deactivate the death menu
        theDeadthMenu.gameObject.SetActive(false);

        // The array of ground is going to be all the platforms with the type/script PlatformDestroyer 
        groundList = FindObjectsOfType<GroundDestroyer>();

        // Make all the floor ahead inactive
        for (int i = 0; i < groundList.Length; i++)
        {
            groundList[i].gameObject.SetActive(false);
        }

        // Reset the position of the player and the platform generator to the start position
        thePlayer.transform.position = playerStartPoint;
        thePlayer.moveSpeed = startSpeed;

        // Reset the platform generator point position
        platformGenerator.transform.position = platformStartPoint;

        // Save the current coins collected
        PlayerPrefs.SetInt("Coins", theScoreManager.coinsCounter);

        // Activate the player obj after restarting it
        thePlayer.gameObject.SetActive(true);

        // Reset the score
        theScoreManager.scoreCounter = 0;
        theScoreManager.scoreIncreasing = true;

        powerupReset = true;
    }
}
