using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialCollectible : MonoBehaviour
{
    [Header("Special Collectible Status")]
    public bool specialCollected;
    private bool inSpecialRange;
    [SerializeField] GameObject enemySpawn;
    private AudioSource audioSource;
    public AudioClip fasterBGM;

    void Update()
    {

    }

    public void Collect()
    {
        audioSource.clip = fasterBGM; 
        audioSource.Play(0);
        GameManager.Instance.collectedCore = true;
        Debug.Log("SpecialCollected becomes true");
        Instantiate(enemySpawn, transform.position, enemySpawn.transform.rotation);
        gameObject.SetActive(false); // Deactivate the collectible
    }

    private void Awake() 
    {
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
    }
}
