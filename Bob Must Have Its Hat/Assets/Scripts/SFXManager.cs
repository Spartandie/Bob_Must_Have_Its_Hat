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

    /*
    private void Awake()
    {
        if(theSFXManager!= null && theSFXManager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        theSFXManager = this;
        DontDestroyOnLoad(this);
    }
    */

    public void PlayeClickSound()
    {
        audio.PlayOneShot(click);
    }

    public void PlayBuySound()
    {
        audio.PlayOneShot(buy);
    }

    public void PlayEquipSound()
    {
        audio.PlayOneShot(equip);
    }

    public void PlayJumpSound()
    {
        audio.PlayOneShot(jump);
    }
}
