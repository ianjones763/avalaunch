using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
   
    public static AudioClip playerRollSound;
    static AudioSource audioSrc;

    void Start()
    {
        playerRollSound = Resources.Load<AudioClip>("snowballRoll");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "snowballRoll":
                audioSrc.PlayOneShot(playerRollSound);
                break;
        }
    }
}
