//Name: Dzann Ku Xin Hui
//File Name: SpecialCollectible.cs
//File Desc: Manages the behavior of a special collectible object in the game, including audio playback, GameManager interaction, and enemy spawning upon collection.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialCollectible : MonoBehaviour
{
    [Header("Special Collectible Status")]
    // Flag indicating whether the special collectible has been collected
    public bool specialCollected;
    // Flag indicating whether the player is in range of the special collectible
    private bool inSpecialRange;
    // Reference to the enemy spawn prefab
    [SerializeField] GameObject enemySpawn;
    // Audio source for playing sound effects
    private AudioSource audioSource;
    // Audio clip for the faster background music
    public AudioClip fasterBGM;

    void Update()
    {
        // Update logic can be added here if needed
    }

    // Method to collect the special collectible
    public void Collect()
    {
        // Change the background music to the faster version
        audioSource.clip = fasterBGM; 
        audioSource.Play(0);

        // Update the GameManager to indicate the core has been collected
        GameManager.Instance.collectedCore = true;
        Debug.Log("SpecialCollected becomes true");

        // Spawn enemies at the collectible's position
        Instantiate(enemySpawn, transform.position, enemySpawn.transform.rotation);

        // Deactivate the collectible
        gameObject.SetActive(false); 
    }

    private void Awake() 
    {
        // Initialize the audio source
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
    }
}
