using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Static reference to access AudioManager from any script
    public static AudioManager instance;

    // Audio clips for pickup and dead sounds
    public AudioClip pickup_Sound;
    public AudioClip dead_Sound;

    void Awake()
    {
        // Create the singleton instance
        MakeInstance();
    }

    void MakeInstance()
    {
        // If no instance exists, assign this one
        if (instance == null)
        {
            instance = this;
        }
    }

    // Play sound when fruit is picked
    public void Play_PickUpS()
    {
        AudioSource.PlayClipAtPoint(pickup_Sound, transform.position);
    }

    // Play sound when player dies (hits bomb or wall)
    public void Play_DeadSound()
    {
        AudioSource.PlayClipAtPoint(dead_Sound, transform.position);
    }

} // class
