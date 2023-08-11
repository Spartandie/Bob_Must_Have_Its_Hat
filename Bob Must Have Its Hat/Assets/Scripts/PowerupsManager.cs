using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsManager : MonoBehaviour
{
    // Variables for the time managmet
    private bool slowMo;
    public float slowMoFactor;

    // Variables to controll the powerups
    private bool invencible;
    private bool powerupActive;
    public float powerupActiveDuration;
    private float powerupDurationCounter;

    // Variables to set the game normal and current speed
    private float gameNormalSpeed;
    private float gameSpeed;

    // A reference to the Player controller
    private PlayerController thePlayerController;

    // A reference to the Time Manager
    private TimeManager theTimeManager;

    // A reference to the Game Manager
    private GameManager theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Here we set thePlayerController, theTimeManager and theGameManager using FindObjectOfType, in this way 
        // Unity handle the search of the desired object so we dont have to do it manually using the UI
        thePlayerController = FindObjectOfType<PlayerController>();
        theTimeManager = FindObjectOfType<TimeManager>();
        theGameManager = FindObjectOfType<GameManager>();

        gameNormalSpeed = 1;
        Time.timeScale = gameNormalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // If any powerup is active
        if (powerupActive)
        {
            // Substract to the powerupDurationCounter so it ends in powerupDurationCounter time
            powerupDurationCounter -= Time.unscaledDeltaTime;

            // If the powerupReset of the theGameManager is true
            if (theGameManager.powerupReset)
            {
                // Reset the power up related varaibles
                powerupDurationCounter = 0;
                theGameManager.powerupReset = false;
            }

            // If the slowMo is true and our time scale is 1 (normal)
            if (slowMo && Time.timeScale >= 1)
            {
                // Make a slowmo
                theTimeManager.DoSlowmo();
            }

            // If invencible is true
            if (invencible)
            {
                // Set invencible as true in thePlayerController
                thePlayerController.invencibleActive = true;
            }

            // Start decreasing the powerupDurationCounter so the power up ends
            powerupDurationCounter -= Time.deltaTime;

            // If the powerupDurationCounter is less or equal 0.09 seconds
            if (powerupDurationCounter <= 0.09)
            {
                // Reset the powerup variables because the powe up time ended
                gameSpeed = gameNormalSpeed;
                thePlayerController.invencibleActive = false;
                powerupActive = false;
            }
        }
    }

    // Function that activates a power up when called
    public void ActivatePowerup(bool slowMoRecived, float slowMoFactorRecived, bool invencibleRecived, float durationRecived)
    {
        // Set the power up related variables so we now have a power up
        slowMo = slowMoRecived;
        slowMoFactor = slowMoFactorRecived;
        invencible = invencibleRecived;
        powerupDurationCounter = durationRecived;
        gameSpeed = gameNormalSpeed;
        powerupActive = true;
    }
}
