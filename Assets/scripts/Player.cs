//Name: Dzann Ku Xin Hui
//File Name: Player.cs
//File Desc: Manages player raycast interactions with various objects in the game environment.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform playerCamera; // Reference to the player's camera
    [SerializeField] float interactionDistance; // Distance within which the player can interact with objects
    [SerializeField] TextMeshProUGUI interactionText; // UI text for interaction prompt
    [SerializeField] TextMeshProUGUI collectCoreText; // UI text for collect core prompt

    // References to interactable objects
    private SpecialCollectible currentSpecialCollectible;
    private Collectible currentCollectible;
    private Door currentDoor;
    private Placeable currentPlaceable;
    private EnterShip currentShip;
    private Button currentButton;

    public GameObject winningScreen;
    // Animator reference
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize references and hide UI texts
        interactionText.gameObject.SetActive(false);
        collectCoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        // Perform raycast to detect interactable objects
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            Debug.Log(hitInfo.collider.gameObject.name);

            // Check for SpecialCollectible
            if (hitInfo.transform.TryGetComponent(out currentSpecialCollectible))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentSpecialCollectible = null;
            }

            // Check for Collectible
            if (hitInfo.transform.TryGetComponent(out currentCollectible))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentCollectible = null;
            }

            // Check for Door
            if (hitInfo.transform.TryGetComponent(out currentDoor))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentDoor = null;
            }

            // Check for Placeable
            if (hitInfo.transform.TryGetComponent(out currentPlaceable))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentPlaceable = null;
            }

            // Check for EnterShip
            if (hitInfo.transform.TryGetComponent(out currentShip))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentShip = null;
            }

            // Check for Button and GameManager condition
            if (hitInfo.transform.TryGetComponent(out currentButton) && GameManager.Instance.placedCore == true)
            {
                interactionText.gameObject.SetActive(true);
            }
            else if (hitInfo.transform.TryGetComponent(out currentButton) && GameManager.Instance.placedCore == false)
            {
                collectCoreText.gameObject.SetActive(true);
            }
            else
            {
                currentButton = null;
            }
        }
        else
        {
            // No object in interaction distance, deactivate UI texts
            interactionText.gameObject.SetActive(false);
            collectCoreText.gameObject.SetActive(false);

            // Reset references
            currentSpecialCollectible = null;
            currentCollectible = null;
            currentDoor = null;
            currentPlaceable = null;
            currentShip = null;
            currentButton = null;
        }
    }

    // If object not null, make interact binding call function.
    public void OnInteract()
    {
        if (currentSpecialCollectible != null)
        {
            currentSpecialCollectible.Collect();
        }

        if (currentCollectible != null)
        {
            currentCollectible.Collect();
        }

        if (currentDoor != null)
        {
            currentDoor.OpenDoor();
        }

        if (currentPlaceable != null)
        {
            currentPlaceable.Place();
        }

        if (currentShip != null)
        {
            currentShip.EnterTheShip();
        }

        if (currentButton != null && GameManager.Instance.placedCore == true)
        {
            currentButton.WinGame();
            winningScreen.SetActive(true);
        }
    }
}