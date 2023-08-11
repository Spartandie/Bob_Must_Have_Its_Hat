using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenu : MonoBehaviour
{

    public string PlayGameLevel;
    public string GoToShop;

    public CharacterDatabase skinsDB;
    private Character characterSkin;
    public GameObject thePlayer;
    public GameObject theBob;

    void Start()
    {
        //Random random = new Random();
        //int selectRandomSkin = random.Next(0, skinsDB.CharacterCount);
        int selectRandomSkin = UnityEngine.Random.Range(0, skinsDB.CharacterCount-1);

        //string skinEquiped = PlayerPrefs.GetString("PlayerEquipedSkin");
        //Debug.Log(skinEquiped);
        //Debug.Log(skinsDB.CharacterCount);

        characterSkin = skinsDB.GetCharacter(selectRandomSkin);//Get the character i from the charactersDB
        /*
        for (int i = 0; i < skinsDB.CharacterCount; i++)
        {
            if (skinEquiped == skinsDB.GetCharacter(i).characterName)
            {
            }
            Debug.Log(skinsDB.GetCharacter(i).characterName);
        }
        */
        SpriteRenderer playerSprite = thePlayer.GetComponent<SpriteRenderer>();
        playerSprite.sprite = characterSkin.characterSprite;  //Nuestra skin;
        playerSprite.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);

        SpriteRenderer bobSprite = theBob.GetComponent<SpriteRenderer>();
        bobSprite.sprite = characterSkin.bobHatlessCharacterSprite;
        //bobSprite.transform.localScale += new Vector3(-0.3f, -0.3f, -0.3f);
        bobSprite.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void PlayGame()
    {
        Application.LoadLevel(PlayGameLevel);
    }

    public void EnterStore()
    {
        Application.LoadLevel(GoToShop);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
