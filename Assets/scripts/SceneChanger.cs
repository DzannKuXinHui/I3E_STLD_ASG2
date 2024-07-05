//Name: Dzann Ku Xin Hui
//File Name: SceneChanger.cs
//File Desc: Handles scene changing functionality triggered by player collision with a specific object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Index of the target scene to load
    public int targetSceneIndex;
    // References to UI elements to hide on scene change
    public GameObject deathScreen;
    public GameObject pauseScreen;

    private void OnTriggerEnter(Collider other)
    {
        // Check whether the object has the "Player" tag
        if (other.tag == "Player")
        {
            // If tag is player, change scene
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        // Load the target scene
        SceneManager.LoadScene(targetSceneIndex);
        // Hide the death and pause screens
        deathScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
}
