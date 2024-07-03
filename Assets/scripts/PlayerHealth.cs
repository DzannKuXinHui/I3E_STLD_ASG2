using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject quitButton;
    public GameObject deathScreen;

    [Header("Health")]
    public int maxHealth = 5;    
    private int currentHealth;
    
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + ". Current health: " + currentHealth);

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
        //         hearts[i].enabled= false;
        //     }
        // }

        if (currentHealth <= 0)
        {
            Die();
        }

        
    }

    private void Die()
    {
        // Handle player death (e.g., respawn, game over screen, etc.)
        Debug.Log("Player died!");
        deathScreen.SetActive(true);
        StartCoroutine(ShowButtons(3f));
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(false);
    }

    private IEnumerator ShowButtons(float delay)
    {
        yield return new WaitForSeconds(delay);

        retryButton.SetActive(true);
        quitButton.SetActive(true);
    }

    

}
