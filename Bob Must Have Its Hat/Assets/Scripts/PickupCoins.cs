using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoins : MonoBehaviour
{

    // Amount of coin currency to add to the player
    public int coinsToGive;

    // A reference to the Score Manager
    private ScoreManager theScoreManager;

    // A reference to the audio source
    [SerializeField] AudioSource coinSFX;

    // Start is called before the first frame update
    void Start()
    {
        // Here we set the Score Manager using FindObjectOfType, in this way Unity handle the search of the desired object
        // so we dont have to do it manually using the UI
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Buit in function in Unity that checks when another object with a 2d collider enters in our trigger zone
    //Gives coins and play coin sound
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddCoins(coinsToGive);


            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            coinSFX.Play();
        }
    }
}