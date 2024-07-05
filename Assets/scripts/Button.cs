//Name: Dzann Ku Xin Hui
//File Name: Button.cs
//File Desc: Manages the winning functionality in the game, specifically playing a sound when the player wins.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private Placeable placedCore; // Reference to Placeable script
    private AudioSource audioSource; // AudioSource to play sound
    public AudioClip audioClip; // AudioClip to play when win
    void Start()
    {
        placedCore = FindObjectOfType<Placeable>(); // Find the Placeable component in scene
    }

    public void WinGame()
    {
        //if (placedCore != null && placedCore.placedCore) // Check if core has been placed
        //{ 
            audioSource = GameObject.Find("BGM").GetComponent<AudioSource>(); // Find the AudioSource on the BGM GameObject
            audioSource.PlayOneShot(audioClip); // Play win sound
        //}
    }
}