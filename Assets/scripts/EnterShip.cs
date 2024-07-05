using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShip : MonoBehaviour
{
    public int targetSceneIndex; // Index of the target scene to load

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