using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoins : MonoBehaviour
{

    // Amount of coin currency to add to the player
    public int coinsToGive;
    //private spriteRenderer renderer;

    private ScoreManager theScoreManager;

    [SerializeField] AudioSource coinSFX;
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Buit in function in Unity that checks when another object with a 2d collider enters in our trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddCoins(coinsToGive);

            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            coinSFX.Play();
        }
    }
}
