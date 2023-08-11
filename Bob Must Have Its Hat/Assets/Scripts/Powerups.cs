using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public bool slowMo;
    public float slowMoFactor;
    public bool invencible;

    public float powerupDuration;
    private bool powerupActive;

    public PowerupsManager thePowerupsManager;

    // Start is called before the first frame update
    void Start()
    {
        thePowerupsManager = FindObjectOfType<PowerupsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            thePowerupsManager.ActivatePowerup(slowMo, slowMoFactor, invencible, powerupDuration);
        }
        gameObject.SetActive(false);
    }
}
