//Name: Dzann Ku Xin Hui
//File Name: Spikes.cs
//File Desc: Controls spike trap animations based on player interaction within a trigger area.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Reference to the animator controlling spike animations
    public Animator animator;

    // Called when a collider enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Activate the spikes animation
            animator.SetBool("spikes", true);
        }
    }

    // Called when a collider exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Deactivate the spikes animation
            animator.SetBool("spikes", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ensure spikes animation is initially deactivated
        animator.SetBool("spikes", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Additional update logic can be added here if needed
    }
}
