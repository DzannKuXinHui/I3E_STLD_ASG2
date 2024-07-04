using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    [SerializeField] GameObject core;
    public bool placedCore;

    void Start()
    {
        placedCore = false; // Correct assignment operator
    }

    void Update()
    {

    }

    public void Place()
    {
        if (GameManager.Instance.collectedCore == true)
        {
            Instantiate(core, transform.position, core.transform.rotation);
            gameObject.SetActive(false); // Deactivate the original core
            placedCore = true; // Correct assignment operator
        }
    }
}