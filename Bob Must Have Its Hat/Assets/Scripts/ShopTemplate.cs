using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopTemplate : MonoBehaviour
{
    // Reference to the title and cost text of each item at the shop
    public TMP_Text titleTxt;
    public TMP_Text costTxt;

    // Reference to the character database (skins database)
    public CharacterDatabase skinsDB;

    // A sprite renderer for the displayed item skin
    public SpriteRenderer skinSprite;

    // Selected skin counter
    private int selectedSkin;

    // Function that updates the player skin at the game
    private void UpdatePlayerSkin(int selectedSkin)
    {
        // Get the "selectedSkin" player skin
        Character player = skinsDB.GetCharacter(selectedSkin);

        // Set the skin sprite as the "selectedSkin"
        skinSprite.sprite = player.characterSprite;
    }

    // Funtion that applies the player skin 
    private void LoadSkin()
    {
        // Get the selected skin of the player at the player prefs
        selectedSkin = PlayerPrefs.GetInt("selectedSkin");
    }

    // Funtion that saves the selected skin of the player
    private void SaveSkin(int selectedSkin)
    {
        // Set the selected skin of the player at the player prefs
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);
    }
}
