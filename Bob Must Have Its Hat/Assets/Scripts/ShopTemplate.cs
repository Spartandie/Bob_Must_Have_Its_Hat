using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopTemplate : MonoBehaviour
{
    public TMP_Text titleTxt;
    //public TMP_Text description;
    //public Sprite skin;   //Created dynamically as a GO
    public TMP_Text costTxt;

    public CharacterDatabase skinsDB;
    public SpriteRenderer skinSprite;


    private int selectedSkin;

    private void UpdatePlayerSkin(int selectedSkin)
    {
        Character player = skinsDB.GetCharacter(selectedSkin);
        skinSprite.sprite = player.characterSprite;

    }

    private void LoadSkin()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin");
    }

    private void SaveSkin(int selectedSkin)
    {
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);
    }
}
