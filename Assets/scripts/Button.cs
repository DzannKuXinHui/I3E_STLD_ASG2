using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Button : MonoBehaviour
{
    Placeable placedCore;
    public GameObject winScreen;

    public int targetSceneIndex;

    // Start is called before the first frame update
    public void WinGame()
    {
        winScreen.SetActive(true);
    }
}
