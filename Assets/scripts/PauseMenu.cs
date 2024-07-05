//Name: Dzann Ku Xin Hui
//File Name: PauseMenu.cs
//File Desc: Manages the game's pause functionality and UI display.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu Settings")]
    // reference to the pause menu UI GameObject
    public GameObject pauseMenu;
    
    // bool to check if the game is paused
    private bool gamePaused;

    void OnPause()
    {
        // see if game is already paused
        gamePaused = !gamePaused;

        // Pause or resume the game based on state
        if (gamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        // Freeze game
        Time.timeScale = 0f;
        // Show pause menu
        pauseMenu.SetActive(true);
    }
        void ResumeGame()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        // Resume game
        Time.timeScale = 1f;
        // Hide pause menu
        pauseMenu.SetActive(false);
    }

    void Start()
    {
        // Ensure pause menu is hidden and the game is not paused
        pauseMenu.SetActive(false);
        gamePaused = false;
    }


    void Update()
    {
 
    }
}
