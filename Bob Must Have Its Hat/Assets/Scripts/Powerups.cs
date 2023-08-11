using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    // Variables for the time managmet
    public bool slowMo;
    public float slowMoFactor;

    // Variables to controll the powerups
    public bool invencible;
    public float powerupDuration;
    private bool powerupActive;

    // A reference to the Power ups Manager
    public PowerupsManager thePowerupsManager;

    // Start is called before the first frame update
    void Start()
    {
        // Here we set thePowerupsManager using FindObjectOfType, in this way Unity handle the search of the desired object 
        // so we dont have to do it manually using the UI
        thePowerupsManager = FindObjectOfType<PowerupsManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Buit in function of Unity that checks when another object with a 2d collider enters in our trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the Player collides with the power up item
        if (other.name == "Player")
        {
            // Start the power up
            thePowerupsManager.ActivatePowerup(slowMo, slowMoFactor, invencible, powerupDuration);
        }

        // Deactivate the power up item so it disapears
        gameObject.SetActive(false);
    }
}
