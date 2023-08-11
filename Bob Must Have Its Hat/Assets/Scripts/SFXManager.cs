using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip click;
    public AudioClip buy;
    public AudioClip equip;
    public AudioClip jump;
    public static SFXManager theSFXManager;

    // Function that plays a sound when the Player clicks on something
    public void PlayeClickSound()
    {
        audio.PlayOneShot(click);
    }

    // Function that plays a sound when the Player buys a skin
    public void PlayBuySound()
    {
        audio.PlayOneShot(buy);
    }

    // Function that plays a sound when the Player equips a skin
    public void PlayEquipSound()
    {
        audio.PlayOneShot(equip);
    }

    // Function that plays a sound when the Player jumps
    public void PlayJumpSound()
    {
        audio.PlayOneShot(jump);
    }
}
