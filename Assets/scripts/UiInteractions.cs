//Name: Dzann Ku Xin Hui
//File Name: UiInteractions.cs
//File Desc: Handles UI interactions, specifically quitting the application when a UI element is clicked.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInteractions : MonoBehaviour
{
    // Method called when the UI element is clicked
    public void ClickFunction()
    {
        // Quit the application
        Application.Quit();
    }
}
