using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactPromptUI;
    public Image inventoryUIImage;

    private float interactRange = 1f;
    private GameObject nearestItem;

    private GameObject inventoryItem;

    void Start()
    {
        interactPromptUI.SetActive(false);
        inventoryUIImage.enabled = false;
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

            if (Input.GetKeyDown("space"))
            {
                InteractWithItem(nearestItem);
            }
        }
        else
        {
            interactPromptUI.SetActive(false);

            if (Input.GetKeyDown("space"))
            {
                if(inventoryItem != null){
                    DropItem();
                }
            }
        }
    }

    void InteractWithItem(GameObject item)
    {
        Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;
        inventoryUIImage.sprite = itemSprite;
        inventoryUIImage.enabled = true;

        inventoryItem = item;
        item.SetActive(false);

    }

        void DropItem()
    {
        inventoryItem.transform.position = transform.position;
        inventoryItem.SetActive(true);
        inventoryUIImage.enabled = false;
        inventoryItem = null;
    }
}
