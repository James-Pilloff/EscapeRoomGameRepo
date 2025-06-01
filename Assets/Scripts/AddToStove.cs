using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToStove : MonoBehaviour
{
    public GameObject stove;
    public GameObject invent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stove.GetComponent<SpriteRenderer>().enabled && stove.GetComponent<StoveManager>().num == 1)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            if (GetComponent<InteractiveDetection>().isInteracting)
            {
                stove.GetComponent<StoveManager>().contents = invent.GetComponent<InventoryManagement>().holding;
                GetComponent<InteractiveDetection>().isInteracting = false;
                invent.GetComponent<InventoryManagement>().holding = "";
            }
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
