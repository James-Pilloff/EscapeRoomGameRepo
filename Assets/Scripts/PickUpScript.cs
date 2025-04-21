using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpScript : MonoBehaviour
{
    public GameObject pickUpPromptUI;
    public Image inventoryUIImage;

    private float pickUpRange = 1f;
    private GameObject nearestItem;

    private GameObject inventoryItem;

    void Start()
    {
        pickUpPromptUI.SetActive(false);
        inventoryUIImage.enabled = false;
    }

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pickUpRange);
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
            pickUpPromptUI.SetActive(true);

            if (Input.GetKeyDown("space"))
            {
                PickUpItem(nearestItem);
            }
        }
        else
        {
            pickUpPromptUI.SetActive(false);

            if (Input.GetKeyDown("space"))
            {
                if(inventoryItem != null){
                    DropItem();
                }
            }
        }
    }

    void PickUpItem(GameObject item)
    {
        if(inventoryItem != null){
            DropItem();
        }
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
