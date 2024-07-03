using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{  
    [Header("References")]
    [SerializeField] Transform playerCamera;
    [SerializeField] float interactionDistance;
    [SerializeField] TextMeshProUGUI interactionText;

    SpecialCollectible currentSpecialCollectible;
    Collectible collectedCrystal;

    Collectible collectedArtifact;

    Collectible collectedBattery;

    Door currentDoor;

    Placeable currentPlaceable;

    public Animator animator;

    Collectible currentCollectible;

    

    
    public void OnInteract()
    {
        if(currentSpecialCollectible != null)
        {
            currentSpecialCollectible.Collect();
        }

        if(currentCollectible != null)
        {
            currentCollectible.Collect();
        }

        if(currentDoor != null)
        {
            currentDoor.OpenDoor();
        }

        if(currentPlaceable != null)
        {
            currentPlaceable.Place();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
            if(hitInfo.transform.TryGetComponent<SpecialCollectible>(out currentSpecialCollectible))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentSpecialCollectible = null;
            }

            if(hitInfo.transform.TryGetComponent<Collectible>(out currentCollectible))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentCollectible = null;
            }

            if(hitInfo.transform.TryGetComponent<Door>(out currentDoor))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentDoor = null;
            }

            if(hitInfo.transform.TryGetComponent<Placeable>(out currentPlaceable))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentPlaceable = null;
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
