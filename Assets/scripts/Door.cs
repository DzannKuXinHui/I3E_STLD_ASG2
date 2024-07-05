//Name: Dzann Ku Xin Hui
//File Name: Door.cs
//File Desc: Controls the opening animation and sound of a door in the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator; // Animator for door animation
    private AudioSource audioSource; // AudioSource to play sound
    public AudioClip audioClip; // AudioClip to play when door opens

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>(); // Find the AudioSource on the BGM GameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        audioSource.PlayOneShot(audioClip); // Play door opening sound
        animator.SetBool("shipdoor", true); // Trigger door open animation
    }
}