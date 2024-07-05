//Name: Dzann Ku Xin Hui
//File Name: Collectible.cs
//File Desc: Handles the collection behavior for different types of collectibles in the game.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int identifier; // Identifier to determine the type of collectible
    private AudioSource audioSource; // AudioSource to play sound
    public AudioClip audioClip; // AudioClip to play when collected

    public void Collect()
    {
        if (identifier == 1)
        {
            GameManager.Instance.collectedCrystal = true; // Mark crystal as collected
            audioSource.PlayOneShot(audioClip); // Play collection sound
            Destroy(gameObject); // Destroy collectible object
        }

        if (identifier == 2)
        {
            GameManager.Instance.collectedArtifact = true; // Mark artifact as collected
            audioSource.PlayOneShot(audioClip); // Play collection sound
            Destroy(gameObject); // Destroy collectible object
        }

        if (identifier == 3)
        {
            GameManager.Instance.collectedBattery = true; // Mark battery as collected
            audioSource.PlayOneShot(audioClip); // Play collection sound
            Destroy(gameObject); // Destroy collectible object
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>(); // Find AudioSource on the BGM GameObject
    }

    // Update is called once per frame
    void Update()
    {

    }
}