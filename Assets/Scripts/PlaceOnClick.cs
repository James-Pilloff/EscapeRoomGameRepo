using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnClick : MonoBehaviour
{
    public GameObject player;
    public GameObject invent;
    public int index;

    string oldItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractiveDetection>().isInteracting)
        {
            oldItem = invent.GetComponent<InventoryManagement>().foods[index];
            invent.GetComponent<InventoryManagement>().foods[index] = invent.GetComponent<InventoryManagement>().holding;
            invent.GetComponent<InventoryManagement>().holding = oldItem;
            GetComponent<InteractiveDetection>().isInteracting = false;
        }
    }
}
