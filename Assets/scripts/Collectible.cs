using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int identifier;

    public void Collect()
    {
        if (identifier == 1)
        {
            GameManager.Instance.collectedCrystal = true;
            Destroy(gameObject);
        }

        if (identifier == 2)
        {
            GameManager.Instance.collectedArtifact = true;
            Destroy(gameObject);
        }

        if (identifier == 3)
        {
            GameManager.Instance.collectedBattery = true;
            Destroy(gameObject);
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