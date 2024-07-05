//Name: Dzann Ku Xin Hui
//File Name: EnterShip.cs
//File Desc: Handles the functionality to transition the player to a new scene when entering a ship or similar object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShip : MonoBehaviour
{
    public int targetSceneIndex; // index of the target scene to load

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterTheShip()
    {
        SceneManager.LoadScene(targetSceneIndex); // Load  scene with specified index num
    }
}