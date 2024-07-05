// Name: Dzann Ku Xin Hui
// File Name: SpikesDmg.cs
// File Desc: Handles damage to the player upon collision with spikes.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDmg : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    private void Awake() 
    {
        // Find and assign the PlayerHealth component on the "PlayerCapsule" GameObject
        playerHealth = GameObject.Find("PlayerCapsule").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Log collision with spikes for debugging purposes
        Debug.Log("Collided with spike");

        // Check if the collider has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Call the TakeDamage method from PlayerHealth to reduce player's health by 1
            playerHealth.TakeDamage(1);
        }
    }
}