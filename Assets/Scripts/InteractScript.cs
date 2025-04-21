using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractScript : MonoBehaviour
{
    public GameObject interactPromptUI;
    private GameObject nearestInteractable;
    private float interactRange = 1f;

    void Start()
    {
        interactPromptUI.SetActive(false);
    }

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);
        float closestDistance = float.MaxValue;
        nearestInteractable = null;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Interactable"))
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestInteractable = hit.gameObject;
                }
            }
        }

        if (nearestInteractable != null)
        {
            interactPromptUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithItem(nearestInteractable);
            }
        } else {
            interactPromptUI.SetActive(false);
        }
    }

    void InteractWithItem(GameObject nearestInteractable){
        IInteractable interactable = nearestInteractable.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}
