using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI;

    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    //public Character[] skins;//poner las skins en el arreglo y cargarlas en cada panel
    public CharacterDatabase skinsDB;
    public string playerSkin;

    public Button[] myPurchaseBtns;
    public Button[] myEquipBtns;

    public string Menu;

    // Start is called before the first frame update
    void Start()
    {   
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }

        getPlayerPrefs();
        coinsUI.text = coins.ToString(); //"Monedas = " + 

        LoadPanels();

        //To reset the PlayerPrefs for testing prouposes
        //PlayerPrefs.SetString("SkinsBought", "Originalli");
        //PlayerPrefs.SetInt("Coins", 0);


        if (!PlayerPrefs.HasKey("PlayerEquipedSkin"))
        {
            PlayerPrefs.SetString("PlayerEquipedSkin", "Originalli");
            PlayerPrefs.SetString("SkinsBought", "Originalli");
            EquipSkin(0);
        }

        CheckPurcheseable();
        CheckEquipable();
        CheckPurcheseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPurcheseable()
    {
        Debug.Log("Entering CheckPurcheseable()\n\n\n");
        string[] skinsBought = GetSkinsBought();
        /*
        bool skinBought;
        for (int i = 0; i < shopItemsSO.Length; i++)
        {

            if( coins >= shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else// if(shopItemsSO[i].equipable)
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
        */
        for (int i = 0; i < skinsBought.Length; i++)
        {
            Debug.Log("Searching: " + skinsBought[i]);
            for (int j = 0; j < shopItemsSO.Length; j++)
            {
                Debug.Log("In shop panel: " + shopItemsSO[j].title);
                if (coins >= shopItemsSO[i].baseCost && !shopItemsSO[j].equipable && j != 0 && shopItemsSO[j].title != skinsBought[i])//
                {
                    myPurchaseBtns[j].gameObject.SetActive(true);
                    myPurchaseBtns[j].interactable = true;
                    Debug.Log("ACTIVE continue");
                }
                else if( shopItemsSO[j].equipable || j == 0 || shopItemsSO[j].title == skinsBought[i])//
                {
                    myPurchaseBtns[j].interactable = false;
                    myPurchaseBtns[j].gameObject.SetActive(false);
                    Debug.Log("Found it in [" + j + "], IN-ACTIVE continue");
                }
                else if(coins < shopItemsSO[i].baseCost)
                {
                    myPurchaseBtns[j].gameObject.SetActive(true);
                    myPurchaseBtns[j].interactable = false;
                }
            }
        }
    }

    public void CheckEquipable()
    {
        Debug.Log("Entering CheckEquipable()");
        string[] skinsBought = GetSkinsBought();
        //For each skin bought, set the btn interactable to true, else false
        for(int i = 0; i < skinsBought.Length; i++)
        {
            Debug.Log("Searching: " + skinsBought[i]);
            for (int j = 0;j < shopItemsSO.Length; j++)
            {
                /*
                if (!myEquipBtns[btnNo].equiped)
                {
                    myEquipBtns[btnNo].equiped = false;
                }
                */
                Debug.Log("In shop panel: " + shopItemsSO[j].title);
                if (shopItemsSO[j].title == skinsBought[i])
                {
                    myEquipBtns[j].gameObject.SetActive(true);
                    myEquipBtns[j].interactable = true;
                    shopItemsSO[j].equipable = true;
                    Debug.Log("Found it in [" + j + "], continue");
                    //break;
                }
                else if(!shopItemsSO[j].equipable)
                {
                    //myEquipBtns[j].interactable = false;
                    myEquipBtns[j].gameObject.SetActive(false);
                }
            }
        }
    }

    public string[] GetSkinsBought()
    {
        string skinsBoughtTmp = PlayerPrefs.GetString("SkinsBought");
        Debug.Log(skinsBoughtTmp);
        string[] skinsBought = skinsBoughtTmp.Split(".");
        Debug.Log("skinsBought:\n");
        for(int i = 0; i < skinsBought.Length; i++)
        {
            Debug.Log(skinsBought[i].ToString());
        }
        return skinsBought;
    }

    public void PurchaseItem( int btnNo )
    {
        if(coins >= shopItemsSO[btnNo].baseCost)
        {
            coins -= shopItemsSO[btnNo].baseCost;
            coinsUI.text = coins.ToString();// "Monedas: " + 

            PlayerPrefs.SetInt("Coins", coins);

            Character characterPurchased = skinsDB.GetCharacter(btnNo);// Get the character i from the charactersDB
            string characterName = characterPurchased.characterName;
            saveBoughtSkin(characterName);

            CheckPurcheseable();
            CheckEquipable();
            CheckPurcheseable();
        }
    }

    public void EquipSkin(int btnNo)
    {
        CheckEquipable();
        Character characterPurchased = skinsDB.GetCharacter(btnNo);// Get the character i from the charactersDB
        string characterName = characterPurchased.characterName;
        //If the skin is unlocked, equip it (the equip btn is interactable)
        PlayerPrefs.SetString("PlayerEquipedSkin", characterName);
        //myEquipBtns[btnNo].equiped = true;
        myEquipBtns[btnNo].interactable = false;
        Debug.Log("Equiping skin:");
        Debug.Log(characterName);

        //CheckEquipable();
    }

    public void getPlayerPrefs()
    {
        coins = PlayerPrefs.GetInt("Coins");

        // Get the player selected skin
        playerSkin = PlayerPrefs.GetString("PlayerEquipedSkin");
    }

    public void saveBoughtSkin(string skinName)
    {
        Debug.Log("Entering saveBoughtSkin()");
        string[] skinsBought = GetSkinsBought();
        bool skinAlredyBought = Array.Exists(skinsBought, element => element == skinName);
        //If the skin is alredy bought, dont add to bought skins, otherwise add it
        if (!skinAlredyBought)
        {
            Array.Resize(ref skinsBought, skinsBought.Length+1);
            skinsBought[skinsBought.Length - 1] = skinName;
            //skinsBought = skinsBought.Append(skinName).ToArray();
        }
        string skinsBoughtPrefsString = "";
        for(int i = 0; i < skinsBought.Length; i++)
        {
            // Get rid of the '.' for the last skin
            if (i == skinsBought.Length - 1)
            {
                skinsBoughtPrefsString += skinsBought[i];
            }
            else
            {
                skinsBoughtPrefsString += skinsBought[i] + '.';
            }
        }

        Debug.Log("skinsBoughtPrefsString: " + skinsBoughtPrefsString);

        PlayerPrefs.SetString("SkinsBought", skinsBoughtPrefsString);
    }

    public void LoadPanels()
    {
        
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopItemsSO[i].equipable = false;
            //shopPanels[i].description.text = shopItemsSO[i].description;
            Character  characterSkin = skinsDB.GetCharacter(i);//Get the character i from the charactersDB
            GameObject skinGO = new GameObject(characterSkin.characterName, typeof(SpriteRenderer));
            Debug.Log(characterSkin.characterName);
            //Instanciate GO
            SpriteRenderer skinSpriteRenderer = skinGO.GetComponent<SpriteRenderer>();
            skinSpriteRenderer.sprite = characterSkin.characterSprite;  //Nuestra skin;
            skinGO.transform.parent = shopPanels[i].transform;
            skinGO.transform.localPosition = new Vector2(0,30);
            skinSpriteRenderer.sortingOrder = 22;

            //Si es Neonix escala de forma diferente ya que el sprite tiene mayor resolución
            if(characterSkin.characterName != "Neonix"){
                skinGO.transform.localScale += new Vector3(-80f, -80f, -80f);   
            }
            else{
                skinGO.transform.localScale += new Vector3(-85f, -85f, -85f);   
            }
            //GameObject skinInItemGO = GameObject.Find("Skin");
            //SpriteRenderer skinInItemGOSpriteRenderer = skinInItemGO.GetComponent<SpriteRenderer>();
            //skinInItemGOSpriteRenderer.sprite = characterSkin.characterSprite;  //Nuestra skin;
            /*
            */
            shopPanels[i].costTxt.text = shopItemsSO[i].baseCost.ToString();
        }
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
