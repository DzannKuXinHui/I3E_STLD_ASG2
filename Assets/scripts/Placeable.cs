using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    [SerializeField] GameObject core;

    void Update()
    {

    }

    public void Place()
    {
        if(GameManager.Instance.collectedCore == true)
        {
        Instantiate(core, transform.position, core.transform.rotation);
        gameObject.SetActive(false); // Deactivate the collectible
        }
    }
}
