using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDmg : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    private void Awake() 
    {
        playerHealth = GameObject.Find("PlayerCapsule").GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter(Collider other) // Updated parameter type to Collision
    {
        Debug.Log("collided with spike");
        if (other.CompareTag("Player")) // Ensure we check the collider's tag
        {
            playerHealth.TakeDamage(1); // Call the method to reduce the player's health by 1
        }
    }

    
}