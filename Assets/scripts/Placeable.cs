using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    [SerializeField] GameObject core; // Core GameObject to place
    public bool placedCore;
    private AudioSource audioSource; // AudioSource to play sound
    public AudioClip audioClip; // AudioClip to play when placed

    void Start()
    {
        placedCore = false; // Initialize placedCore as false
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>(); // Find the AudioSource on the "BGM" GameObject
    }

    void Update()
    {

    }

    public void Place()
    {
        if (GameManager.Instance.collectedCore == true) // Check if core has been collected
        {
            GameManager.Instance.placedCore = true; // Update the GameManager placedCore bool
            Instantiate(core, transform.position, core.transform.rotation); // Create core at the current position
            gameObject.SetActive(false); // despawn the original object
            placedCore = true; // placedcore bool set true
            audioSource.PlayOneShot(audioClip); // Play sound
        }
    }
}