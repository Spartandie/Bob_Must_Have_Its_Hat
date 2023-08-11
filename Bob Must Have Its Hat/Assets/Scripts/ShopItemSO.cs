using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a new Menu option
[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New Show Item", order = 1)]
// Class of SO, Scriptable Object, wich is like a data storage object
public class ShopItemSO : ScriptableObject
{
    // Variables of the shop item Scriptable Object
    public string title;
    public string playerSpriteName;
    public ShopTemplate theShopTemplate;
    public int baseCost;

    public bool equipable;
}

