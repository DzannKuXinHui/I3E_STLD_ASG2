using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the slider
    public AudioSource audioSource; // Reference to the audio source

    void Start()
    {
        // Ensure that the slider value is synchronized with the audio source volume at start
        if (audioSource != null && volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    // Method to change the volume
    public void ChangeVolume(float value)
    {
        if (audioSource != null)
        {
            audioSource.volume = value;
        }
    }
}
