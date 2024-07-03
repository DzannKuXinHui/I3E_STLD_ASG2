using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
     [Header("PauseMenu")]
    public GameObject pauseMenu;
    private bool gamePaused;

    void OnPause()
    {
        gamePaused = !gamePaused;

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
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; // Freeze the game
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; // Resume the game
        pauseMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
