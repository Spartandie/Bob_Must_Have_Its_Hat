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

    // If the player is still alive bool
    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        // If the player have a High Score saved, set it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Get the value stored in the HighScore PlayerPref
            highScoreCounter = PlayerPrefs.GetFloat("HighScore");
        }

        // If the player have coins saved, set them
        if (PlayerPrefs.HasKey("Coins"))
        {
            // Get the value stored in the Coins PlayerPref
            coinsCounter = PlayerPrefs.GetInt("Coins");
        }
    }

    // Update is called once per frame
    void Update()
    {

        // If the player is still alive or the game isn't paused
        if (scoreIncreasing)
        {
            // Add the respective points respective to the time the frame takes to hapen, so that in 1 sec we end up having
            // pointsPerSecond points in our scoreConter
            scoreCounter += pointsPerSecond * Time.deltaTime;
        }

        // If the player Score is greater than his previuos high score update the high score
        if (scoreCounter > highScoreCounter)
        {
            // Set the high score counter
            highScoreCounter = scoreCounter;

            // Save the High Score of the player in his player prefs
            PlayerPrefs.SetFloat("HighScore", highScoreCounter);
        }

        // Update the score text
        scoreText.text = "Dist.: " + Mathf.Round(scoreCounter) + " Km";

        // Update the high score text
        HighscoreText.text = "Dist. max.: " + Mathf.Round(highScoreCounter) + " Km";

        // Update the coins text
        coinsText.text = coinsCounter.ToString();
    }

    // Function that adds "coinsToAdd" coins to the player
    public void AddCoins(int coinsToAdd)
    {
        // Add "coinsToAdd" coins to the "coinsCounter" variable of the player
        coinsCounter += coinsToAdd;
    }
}
