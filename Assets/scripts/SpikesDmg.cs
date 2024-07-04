using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDmg : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    void OnCollisionEnter(Collision collision) // Updated parameter type to Collision
    {
        if (collision.collider.CompareTag("Player")) // Ensure we check the collider's tag
        {
            playerHealth.TakeDamage(1); // Call the method to reduce the player's health by 1
        }
    }
}