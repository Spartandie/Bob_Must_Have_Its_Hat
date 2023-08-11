using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class ShopManager : MonoBehaviour
{
    // Variable that count the amount of coins the player have
    public int coins;

    // A reference to the coins text in the UI
    public TMP_Text coinsUI;

    // A array of our Scriptable Object Shop Items
    public ShopItemSO[] shopItemsSO;

    // A array of our Empty Game Object Shop Panels
    public GameObject[] shopPanelsGO;

    // A array of our empty Shop Panels 
    public ShopTemplate[] shopPanels;

    // A reference to the Skins Data Base
    public CharacterDatabase skinsDB;

    // A variable that holds the name of the player skin
    public string playerSkin;

    // Array of all the purchase buttons at the store
    public Button[] myPurchaseBtns;

    // Array of all the equip buttons at the store
    public Button[] myEquipBtns;

    // The name of the Menu scene
    public string Menu;

    // Start is called before the first frame update
    void Start()
    {
        // Activate "shopItemsSO.Length" Game Objects Shop Panels
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }

        // Get the player prefs
        getPlayerPrefs();

        // Update the coins UI text to display the amount of coins the player has
        coinsUI.text = coins.ToString();

        // Load the panels of the shop
        LoadPanels();

        // If it's the first time the game is launched, the player wont have a skin equiped, so we equip the default one
        if (!PlayerPrefs.HasKey("PlayerEquipedSkin"))
        {
            // Set the Default skin at the players prefs
            PlayerPrefs.SetString("PlayerEquipedSkin", "Originalli");
            PlayerPrefs.SetString("SkinsBought", "Originalli");

            // Equip the default skin
            EquipSkin(0);
        }

        // Check the purcheasable skins
        CheckPurcheseable();

        // Check the equipable skins
        CheckEquipable();

        // Check the purcheasable skins
        CheckPurcheseable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function that checks the purcheasable skins
    public void CheckPurcheseable()
    {
        // Get the skins bought
        string[] skinsBought = GetSkinsBought();

        // For each skin bougth, deactive the buy button so the player cant buy it again
        for (int i = 0; i < skinsBought.Length; i++)
        {
            // For each shop item
            for (int j = 0; j < shopItemsSO.Length; j++)
            {
                // If the player have enogh coins to buy the item wich must not be equipable, and the items name is not a bught skin
                if (coins >= shopItemsSO[i].baseCost && !shopItemsSO[j].equipable && j != 0 && shopItemsSO[j].title != skinsBought[i])
                {
                    // Activate the purchase button of the item
                    myPurchaseBtns[j].gameObject.SetActive(true);
                    myPurchaseBtns[j].interactable = true;
                } // if not but the shop item is equipable or it's the default skin or the item name is equal to a bought skin
                else if (shopItemsSO[j].equipable || j == 0 || shopItemsSO[j].title == skinsBought[i])//
                {
                    // Deactivate the purchase button of the item
                    myPurchaseBtns[j].interactable = false;
                    myPurchaseBtns[j].gameObject.SetActive(false);
                } // If not but the player don't have enought coins to buy it 
                else if (coins < shopItemsSO[i].baseCost)
                {
                    // Deactivate the purchase button of the item
                    myPurchaseBtns[j].gameObject.SetActive(true);
                    myPurchaseBtns[j].interactable = false;
                }
            }
        }
    }

    // Function that updates the equipability of each skin
    public void CheckEquipable()
    {
        // Get the skins bought
        string[] skinsBought = GetSkinsBought();

        //For each skin bought, set the button interactable to true, else false
        for (int i = 0; i < skinsBought.Length; i++)
        {
            for (int j = 0; j < shopItemsSO.Length; j++)
            {
                // If the shop panel title is equal to our skin
                if (shopItemsSO[j].title == skinsBought[i])
                {
                    // Activate the equip button
                    myEquipBtns[j].gameObject.SetActive(true);
                    myEquipBtns[j].interactable = true;
                    shopItemsSO[j].equipable = true;
                }// If not and the Item shuld not be equipable
                else if (!shopItemsSO[j].equipable)
                {
                    //  Deactivate the equip button
                    myEquipBtns[j].gameObject.SetActive(false);
                }
            }
        }
    }

    // Function that return a list of strings with all the bought skins
    public string[] GetSkinsBought()
    {
        // Get the skins bought from the player prefs
        string skinsBoughtTmp = PlayerPrefs.GetString("SkinsBought");

        // Create list of skins splitting the skinsBoughtTmp string by the "."
        string[] skinsBought = skinsBoughtTmp.Split(".");

        // For each skin bought, print its name in the debug log console
        // for (int i = 0; i < skinsBought.Length; i++)
        // {
        //     Debug.Log(skinsBought[i].ToString());
        // }

        // Return the list of skins bought
        return skinsBought;
    }

    // Function that gets the item number to buy and buy it
    public void PurchaseItem(int btnNo)
    {
        // If the player have an equal or grater amount of coins than the base cost of the item to buy
        if (coins >= shopItemsSO[btnNo].baseCost)
        {
            // Thake the base cost of coins away for the player
            coins -= shopItemsSO[btnNo].baseCost;

            // Update the coins UI text displayed
            coinsUI.text = coins.ToString();

            // Update the player prefs coins
            PlayerPrefs.SetInt("Coins", coins);

            // Get the character "btnNo" from the charactersDB
            Character characterPurchased = skinsDB.GetCharacter(btnNo);

            // Get the name of the purchased skin
            string characterName = characterPurchased.characterName;

            // Save the bought skin
            saveBoughtSkin(characterName);

            // Check the purcheseable skins
            CheckPurcheseable();

            // Check the equipable skins
            CheckEquipable();

            // Check the purcheseable skins
            CheckPurcheseable();
        }
    }

    // Function that equips the "btnNo" skin to the player, the skins are saved in our skinsDB
    public void EquipSkin(int btnNo)
    {
        // Check if we can equip the "btnNo" skin to the player
        CheckEquipable();

        // Get the character "i" from the charactersDB
        Character characterPurchased = skinsDB.GetCharacter(btnNo);

        // Get the name of the skin
        string characterName = characterPurchased.characterName;

        //If the skin is unlocked, equip it (if the equip button is interactable)
        PlayerPrefs.SetString("PlayerEquipedSkin", characterName);

        myEquipBtns[btnNo].interactable = false;
    }

    // Function that Get the Player Prefs
    public void getPlayerPrefs()
    {
        // Get the amount of coins the player have
        coins = PlayerPrefs.GetInt("Coins");

        // Get the player selected skin
        playerSkin = PlayerPrefs.GetString("PlayerEquipedSkin");
    }

    // Function that gets a skin name and save it in the players pref
    public void saveBoughtSkin(string skinName)
    {
        // Get the skins bought
        string[] skinsBought = GetSkinsBought();

        // If the "skinName" is saved in the "skinsBought" array, set skinAlredyBought to true
        bool skinAlredyBought = Array.Exists(skinsBought, element => element == skinName);

        //If the skin is alredy bought, dont add it to the bought skins, otherwise add it
        if (!skinAlredyBought)
        {
            Array.Resize(ref skinsBought, skinsBought.Length + 1);
            skinsBought[skinsBought.Length - 1] = skinName;
        }

        // Temporal string to save later on the skins bought
        string skinsBoughtPrefsString = "";

        // For each skin bought, add it to the "skinsBoughtPrefsString" string, using a "." as spacer
        for (int i = 0; i < skinsBought.Length; i++)
        {
            // Get rid of the '.' for the last skin
            if (i == skinsBought.Length - 1)
            {
                skinsBoughtPrefsString += skinsBought[i];
            } // Append the "i" skin to the "skinsBoughtPrefsString" string
            else
            {
                skinsBoughtPrefsString += skinsBought[i] + '.';
            }
        }

        // Set the sking bought player prefs
        PlayerPrefs.SetString("SkinsBought", skinsBoughtPrefsString);
    }

    // Function that Pupulates "shopItemsSO.Length" number of panels in the store, so they
    // show the "shopItemsSO.Length" itens that are in sale
    public void LoadPanels()
    {
        // For each Scriptable Object Item
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            // Update the title and equipable bool of the item
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopItemsSO[i].equipable = false;

            //Get the character i from the charactersDB
            Character characterSkin = skinsDB.GetCharacter(i);

            // Create the Game Object for the skin that will populate the Item
            GameObject skinGO = new GameObject(characterSkin.characterName, typeof(SpriteRenderer));

            // Create a Sprite Renderer for our skin Game Object
            SpriteRenderer skinSpriteRenderer = skinGO.GetComponent<SpriteRenderer>();

            // Set the skin in the item
            skinSpriteRenderer.sprite = characterSkin.characterSprite;

            // Instanciate the skin Game Object in the Item
            skinGO.transform.parent = shopPanels[i].transform;
            skinGO.transform.localPosition = new Vector2(0, 30);

            // Change the sprite sortin order so it's on top
            skinSpriteRenderer.sortingOrder = 22;

            //If Neonix the scale is different (Neonix has bigger resolution)
            if(characterSkin.characterName != "Neonix"){
                skinGO.transform.localScale += new Vector3(-80f, -80f, -80f);   
            }
            else{
                skinGO.transform.localScale += new Vector3(-85f, -85f, -85f);   
            }
            // Set the cost for the "i" item
            shopPanels[i].costTxt.text = shopItemsSO[i].baseCost.ToString();
        }

    }

    // Function that changes the scene to the "menu"
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
