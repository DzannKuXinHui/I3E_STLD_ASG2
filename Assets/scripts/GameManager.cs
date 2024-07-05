//Name: Dzann Ku Xin Hui
//File Name: GameManager.cs
//File Desc: Manages global game state and persistence across scenes, including player progress and audio management.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Bool for if the player has the special collectible item
    public bool HasSpecialCollectible;

    // Singleton instance of GameManager
    public static GameManager Instance;

    // Bools for tracking collected items
    public bool collectedBattery;
    public bool collectedArtifact;
    public bool collectedCrystal;
    public bool collectedCore;

    // Audio source for background music
    private AudioSource audioSource;

    // indicates if the core has been placed
    public bool placedCore;

    private void Awake()
    {
        // Find and play the background music audio source
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        audioSource.Play(0);

        // Implement the singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keep GameManager across scenes.
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // to make sure only one instance of GameManager exists.
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}