using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool HasSpecialCollectible;

    public static GameManager Instance;
    public bool collectedBattery;
    public bool collectedArtifact;
    public bool collectedCrystal;
    public bool collectedCore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist GameManager across scenes.
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject);            // Ensure only one instance of GameManager exists.
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
