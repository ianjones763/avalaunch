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
        audioSrc.volume = 0.3f;
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "snowballRoll":
                if (!audioSrc.isPlaying) 
                {
                    audioSrc.PlayOneShot(playerRollSound);
                }
                break;
        }
    }
}
