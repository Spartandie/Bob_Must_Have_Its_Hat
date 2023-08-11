using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To use UI stuff
using UnityEngine.UI;

public class DeathMenuManager : MonoBehaviour
{
    // Our scores text in the UI
    public Text scoreText;
    public Text highScoreText;
    public Text coinsText;

    private float currentScore;
    private float maxScore;
    private int coins;

    public CharacterDatabase skinsDB;
    private Character characterSkin;
    public GameObject thePlayer;
    public GameObject theBob;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Get the value stored in the HighScore PlayerPref
            maxScore = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            // Get the value stored in the Coins PlayerPref
            coins = PlayerPrefs.GetInt("Coins");
        }

        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            // Get the value stored in the Curent Scocre PlayerPref
            currentScore = PlayerPrefs.GetFloat("CurrentScore");
        }
        else
        {
            currentScore = 0f;
        }

        scoreText.text = "Dist.: " + Mathf.Round(currentScore) + " Km";
        highScoreText.text = "Dist. máx.: " + Mathf.Round(maxScore) + " Km";
        coinsText.text = coins.ToString();

        string skinEquiped = PlayerPrefs.GetString("PlayerEquipedSkin");
        //Debug.Log(skinEquiped);
        //Debug.Log(skinsDB.CharacterCount);

        for (int i = 0; i < skinsDB.CharacterCount; i++)
        {
            if (skinEquiped == skinsDB.GetCharacter(i).characterName)
            {
                characterSkin = skinsDB.GetCharacter(i);//Get the character i from the charactersDB
            }
            Debug.Log(skinsDB.GetCharacter(i).characterName);
        }

        SpriteRenderer playerSprite = thePlayer.GetComponent<SpriteRenderer>();
        playerSprite.sprite = characterSkin.characterHatlessDeadSprite;
        playerSprite.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        playerSprite.transform.Rotate(Vector3.forward*2);

        SpriteRenderer bobSprite = theBob.GetComponent<SpriteRenderer>();
        bobSprite.sprite = characterSkin.bobCharacterSprite;
        bobSprite.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        bobSprite.transform.Rotate(Vector3.forward * 2);
    }

    public void RestarGame()
    {
        //FindObjectOfType<GameManager>().ResetPlayer();
        Application.LoadLevel("EndlessRuner");
    }

    public void QuitToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }
}

