using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsManager : MonoBehaviour
{

    private bool slowMo;
    public float slowMoFactor;
    private bool invencible;

    private bool powerupActive;
    public float powerupActiveDuration;

    private float powerupDurationCounter;

    private PlayerController thePlayerController;
    private TimeManager theTimeManager;
    //private string killBoxNormalTag = "killBox";
    //private string killboxTag;
    private float gameNormalSpeed;
    private float gameSpeed;

    private GameManager theGameManager;


    // Start is called before the first frame update
    void Start()
    {
        thePlayerController = FindObjectOfType<PlayerController>();
        theTimeManager = FindObjectOfType<TimeManager>();
        theGameManager = FindObjectOfType<GameManager>();
        gameNormalSpeed = 1;
        Time.timeScale = gameNormalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupActive)
        {
            powerupDurationCounter -= Time.unscaledDeltaTime;
            Debug.Log("powerupDurationCounter: " + powerupDurationCounter);

            if (theGameManager.powerupReset)
            {
                powerupDurationCounter = 0;
                theGameManager.powerupReset = false;
            }

            if (slowMo && Time.timeScale >= 1)
            {
                Debug.Log("Doing DoSlowmo");
                theTimeManager.DoSlowmo();//(slowMoFactor, powerupActiveDuration);
            }
            /*
            if (slowMo)
            {
                
            }
            */
            // In function OnCollitionEnter2D()
            if (invencible)
            {
                thePlayerController.invencibleActive = true;
            }
            

            powerupDurationCounter -= Time.deltaTime;

            if (powerupDurationCounter <= 0.09)
            {
                Debug.Log("Voy a resetear el powerup");
                gameSpeed = gameNormalSpeed;
                thePlayerController.invencibleActive = false;
                //killboxTag = killBoxNormalTag;
                powerupActive = false;
            }
        }
    }

    public void ActivatePowerup(bool slowMoRecived, float slowMoFactorRecived, bool invencibleRecived, float durationRecived)
    {
        slowMo = slowMoRecived;
        slowMoFactor = slowMoFactorRecived;
        invencible = invencibleRecived;
        powerupDurationCounter = durationRecived;

        gameSpeed = gameNormalSpeed;
        //killboxTag = thePlayerController.killBoxTag;


        powerupActive = true;
    }
}
