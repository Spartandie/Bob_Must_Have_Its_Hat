using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenu : MonoBehaviour
{
    // Name of the game scene
    public string PlayGameLevel;

    // Name of the shop scene
    public string GoToShop;

    // Reference to the character database (skins database) 
    public CharacterDatabase skinsDB;

    // Reference to a character(skin) 
    private Character characterSkin;

    // Reference to the player
    public GameObject thePlayer;

    // Reference to the bob
    public GameObject theBob;

    void Start()
    {
        // Generate a number between 0 and the amoun of skins in the game -1
        int selectRandomSkin = UnityEngine.Random.Range(0, skinsDB.CharacterCount - 1);

        //Get the character i from the charactersDB
        characterSkin = skinsDB.GetCharacter(selectRandomSkin);

        // Create a Sprite renderer for the player
        SpriteRenderer playerSprite = thePlayer.GetComponent<SpriteRenderer>();

        // Equip the skin;
        playerSprite.sprite = characterSkin.characterSprite;

        // Position the skin;
        playerSprite.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);

        // Create a Sprite renderer for the bob
        SpriteRenderer bobSprite = theBob.GetComponent<SpriteRenderer>();

        // Equip the skin;
        bobSprite.sprite = characterSkin.bobHatlessCharacterSprite;

        // Position the skin;
        bobSprite.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }

    // Function that loads the game scene
    public void PlayGame()
    {
        Application.LoadLevel(PlayGameLevel);
    }

    // Function that loads the store scene
    public void EnterStore()
    {
        Application.LoadLevel(GoToShop);
    }

    // Function that quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
