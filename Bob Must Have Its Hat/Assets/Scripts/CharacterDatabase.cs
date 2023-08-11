using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add an option to the asset menu called character database
[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    // Array of characters (skins)
    public Character[] character;

    // Function that return the amount of characters (skins) saved
    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    // Function that return the character (skin) at the index provided
    public Character GetCharacter(int index)
    {
        return character[index];
    }
}
