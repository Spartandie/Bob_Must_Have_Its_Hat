using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    public Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    public float startSpeed;

    public BobController theBob;
    private Vector3 bobStartPoint;

    // Array of ground
    private GroundDestroyer[] groundList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeadthMenu;
    public string theDeathScene;

    public PauseMenu thePauseButton;

    public bool powerupReset;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlayer.moveSpeed = startSpeed;

        /*
        bobStartPoint = theBob.transform.position;
        theBob.moveSpeed = startSpeed;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            thePauseButton.PauseGame();
        }
        */

        /*
        if (thePauseMenu.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKey("p") || Input.GetKey("P") || Input.GetKey("c") || Input.GetKey("C"))
            {
                thePauseMenu.UnpauseGame();
            }
        }
        */
    }

    public void RestartGame()
    {
        // Start the coroutine named in the function call
        // StartCoroutine("RestartGameCoroutine");

        theScoreManager.scoreIncreasing = false;

        // Deactivate the player obj to restart it
        thePlayer.gameObject.SetActive(false);

        //theBob.gameObject.SetActive(false);

        PlayerPrefs.SetFloat("CurrentScore",theScoreManager.scoreCounter);
        PlayerPrefs.SetInt("Coins", theScoreManager.coinsCounter);

        theDeadthMenu.gameObject.SetActive(true);
        Application.LoadLevel(theDeathScene);


    }

    // Reset the player
    public void ResetPlayer()
    {
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
        
        /*
        theBob.transform.position = bobStartPoint;
        theBob.moveSpeed = startSpeed;
        */

        platformGenerator.transform.position = platformStartPoint;

        // Save the current coins collected
        PlayerPrefs.SetInt("Coins", theScoreManager.coinsCounter);

        // Activate the player obj after restarting it
        thePlayer.gameObject.SetActive(true);
        
        //theBob.gameObject.SetActive(true);

        theScoreManager.scoreCounter = 0;
        theScoreManager.scoreIncreasing = true;

        powerupReset = true;
    }

    /*
    public IEnumerator RestartGameCoroutine()
    {
        theScoreManager.scoreIncreasing = false;

        // Deactivate the player obj to restart it
        thePlayer.gameObject.SetActive(false);

        // Add a delay of 0.5 seconds to the coroutine
        yield return new WaitForSeconds(0.5f);

        // The array of ground is going to be all the platforms with the type/script PlatformDestroyer 
        groundList = FindObjectsOfType<GroundDestroyer>();

        // Make all the floor ahead inactive
        for( int i = 0; i<groundList.Length; i++)
        {
            groundList[i].gameObject.SetActive(false);
        }

        // Reset the position of the player and the platform generator to the start position
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.transform.position = platformStartPoint;

        // Save the current coins collected
        PlayerPrefs.SetInt("Coins", theScoreManager.coinsCounter);

        // Activate the player obj after restarting it
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCounter = 0;
        theScoreManager.scoreIncreasing = true;
    }
    */
}
