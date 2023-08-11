using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To use UI stuff
using UnityEngine.UI;

public class DeathMenuManager : MonoBehaviour
{
    // The scores texts in the UI
    public Text scoreText;
    public Text highScoreText;
    private float currentScore;
    private float maxScore;

    // The coin text in the UI
    public Text coinsText;

    private int coins;

    // A reference to the character database (skins database)
    public CharacterDatabase skinsDB;

    // A character (skin)
    private Character characterSkin;

    // A reference to the player Game Object
    public GameObject thePlayer;

    // A reference to the bob Game Object
    public GameObject theBob;

    // Start is called before the first frame update
    void Start()
    {
        // If the player have a High Score saved, set it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Get the value stored in the HighScore PlayerPref
            maxScore = PlayerPrefs.GetFloat("HighScore");
        }

        // If the player have coins saved, set them
        if (PlayerPrefs.HasKey("Coins"))
        {
            // Get the value stored in the Coins PlayerPref
            coins = PlayerPrefs.GetInt("Coins");
        }

        // If the player have a current score saved, set ir
        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            // Get the value stored in the Curent Scocre PlayerPref
            currentScore = PlayerPrefs.GetFloat("CurrentScore");
        }
        else
        {
            currentScore = 0f;
        }

        // Update the score, high score and coins texts of the UI
        scoreText.text = "Dist.: " + Mathf.Round(currentScore) + " Km";
        highScoreText.text = "Dist. m�x.: " + Mathf.Round(maxScore) + " Km";
        coinsText.text = coins.ToString();

        // Get the player equiped skin
        string skinEquiped = PlayerPrefs.GetString("PlayerEquipedSkin");

        // For each skin at our skins database search the equiped one
        for (int i = 0; i < skinsDB.CharacterCount; i++)
        {
            // If the name of our equiped skin is equal to the "i" skin at our skins database
            if (skinEquiped == skinsDB.GetCharacter(i).characterName)
            {
                //Get the character i from the charactersDB
                characterSkin = skinsDB.GetCharacter(i);
            }
        }

        // Create a Sprite Renderer for the player skin
        SpriteRenderer playerSprite = thePlayer.GetComponent<SpriteRenderer>();

        // Set the player equiped skin
        playerSprite.sprite = characterSkin.characterHatlessDeadSprite;

        // Resize and position the skin
        playerSprite.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        playerSprite.transform.Rotate(Vector3.forward * 2);

        // Create a Sprite Renderer for the player skin
        SpriteRenderer bobSprite = theBob.GetComponent<SpriteRenderer>();

        // Set the bob equiped skin
        bobSprite.sprite = characterSkin.bobCharacterSprite;

        // Resize and position the skin
        bobSprite.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        bobSprite.transform.Rotate(Vector3.forward * 2);
    }

    // Function that restart the game by reloading the game scene
    public void RestarGame()
    {
        Application.LoadLevel("EndlessRuner");
    }

    // Function that loads the main menu scene
    public void QuitToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }
}

