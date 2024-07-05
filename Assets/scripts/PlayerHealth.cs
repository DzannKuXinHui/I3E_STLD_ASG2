//Name: Dzann Ku Xin Hui
//File Name: PlayerHealth.cs
//File Desc: Manages the player's health, including damage taking, health UI, player death, and death screen interaction.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // UI elements for the death screen
    public GameObject retryButton;
    public GameObject quitButton;
    public GameObject deathScreen;

    [Header("Health")]
    // Maximum health of the player
    public int maxHealth = 5;
    // Current health of the player
    private int currentHealth;

    // Number of heart icons to display
    public int numOfHearts;

    // Array of heart images for the health UI
    public Image[] hearts;
    // Sprites for full and empty heart icons
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Audio source for playing sound effects
    private AudioSource audioSource;
    // Audio clip for the death sound
    public AudioClip audioClip;

    private void Awake()
    {
        // Initialize the audio source and set current health to max health
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Reduce current health by damage amount
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + ". Current health: " + currentHealth);

        // Update the heart icon to reflect damage taken
        hearts[currentHealth].enabled = false;

        // for (int i = 0; i < hearts.Length; i++)
        // {
        //     if(i < maxHealth)
        //     {
        //         hearts[i].sprite = fullHeart;
        //     }
        //     else
        //     {
        //         hearts[i].sprite = emptyHeart;
        //     }
        //     if(i < numOfHearts)
        //     {
        //         hearts[i].enabled = true;
        //     }
        //     else
        //     {
        //         hearts[i].enabled = false;
        //     }
        // }

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play the death sound
        audioSource.PlayOneShot(audioClip);
        Debug.Log("Player died!");
        
        // Show the death screen
        deathScreen.SetActive(true);
        
        // Show retry and quit buttons after a delay
        StartCoroutine(ShowButtons(3f));
        
        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        
        // Deactivate the player object
        gameObject.SetActive(false);
    }

    private IEnumerator ShowButtons(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        retryButton.SetActive(true);
        quitButton.SetActive(true);
    }
}
