using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To use UI stuff
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Our scores text in the UI
    public Text scoreText;
    public Text HighscoreText;
    public Text coinsText;

    // Scores counters to update text
    public float scoreCounter;
    public float highScoreCounter;
    public int coinsCounter;

    public float pointsPerSecond;

    // If the player is still alive
    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Get the value stored in the HighScore PlayerPref
            highScoreCounter = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            // Get the value stored in the Coins PlayerPref
            coinsCounter = PlayerPrefs.GetInt("Coins");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (scoreIncreasing)
        {
            // Add the respective points respective to the time the frame takes to hapen, so that in 1 sec we end up having
            // pointsPerSecond points in our scoreConter
            scoreCounter += pointsPerSecond * Time.deltaTime;
        }

        if( scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;

            // A simple way to save data
            PlayerPrefs.SetFloat("HighScore", highScoreCounter);
        }

        scoreText.text = "Dist.: " + Mathf.Round(scoreCounter) + " Km";
        HighscoreText.text = "Dist. máx.: " + Mathf.Round(highScoreCounter) + " Km";

        coinsText.text = coinsCounter.ToString();//"Coins: " + 
    }

    public void AddCoins(int coinsToAdd)
    {
        coinsCounter += coinsToAdd;
    }
}
