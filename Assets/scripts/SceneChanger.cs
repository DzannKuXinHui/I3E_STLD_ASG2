using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChanger : MonoBehaviour
{
    public int targetSceneIndex;
    public GameObject deathScreen;
    public GameObject pauseScreen;

    private void OnTriggerEnter(Collider other)
    {
        //check whether the object has the "Player" tag
        if(other.tag == "Player")
        {
            //if tag is player, change scene
            ChangeScene();
        }
    }   

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
        deathScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
}
