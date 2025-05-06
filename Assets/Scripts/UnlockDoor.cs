using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject invent;
    public GameObject door;
    public GameObject mouse;
    public string mouseTag;
    public string item;

    private bool notUsed;
    private bool wasClicked;
    private bool isClicked;
    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        notUsed = true;
        contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(Physics2D.AllLayers);
        contactFilter.useLayerMask = true;
        isClicked = false;
        wasClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = invent.GetComponent<InventoryManagement>().holding == item && notUsed && door.GetComponent<InteractiveDetection>().isInteracting;
        GetComponent<Collider2D>().enabled = invent.GetComponent<InventoryManagement>().holding == item && notUsed && door.GetComponent<InteractiveDetection>().isInteracting;
        
        results.Clear();
        GetComponent<Collider2D>().OverlapCollider(contactFilter, results);

        isClicked = false;

        for (int index = 0; index < results.Count; index++)
        {
            if (results[index].tag == mouseTag)
            {
                isClicked = true;
            }
        }

        if (isClicked && !wasClicked)
        {
            door.GetComponent<DoorLock>().isLocked = false;
            notUsed = false;
            door.GetComponent<InteractiveDetection>().isInteracting = false;
        }

        wasClicked = mouse.GetComponent<Collider2D>().enabled;
    }
}
