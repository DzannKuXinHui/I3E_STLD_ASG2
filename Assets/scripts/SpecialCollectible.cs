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

    void Update()
    {

    }

    public void Collect()
    {
        GameManager.Instance.collectedCore = true;
        Debug.Log("SpecialCollected becomes true");
        Instantiate(enemySpawn, transform.position, enemySpawn.transform.rotation);
        gameObject.SetActive(false); // Deactivate the collectible
    }
}
