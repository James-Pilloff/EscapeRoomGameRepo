using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactPromptUI;
    private float interactRange = 2f;
    private GameObject nearestItem;

    void Start()
    {
        interactPromptUI.SetActive(false);
    }

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);
        float closestDistance = float.MaxValue;
        nearestItem = null;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Item"))
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestItem = hit.gameObject;
                }
            }
        }

        if (nearestItem != null)
        {
            interactPromptUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithItem(nearestItem);
            }
        }
        else
        {
            interactPromptUI.SetActive(false);
        }
    }

    void InteractWithItem(GameObject item)
    {
        Debug.Log("Picked up: " + item.name);
        // Add your item pickup logic here
        Destroy(item); // Simple: remove item from scene
        interactPromptUI.SetActive(false);
    }
}
