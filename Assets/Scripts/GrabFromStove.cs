using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFromStove : MonoBehaviour
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
        if (stove.GetComponent<SpriteRenderer>().enabled && stove.GetComponent<StoveManager>().num == 2)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            if (GetComponent<InteractiveDetection>().isInteracting)
            {
                invent.GetComponent<InventoryManagement>().holding = stove.GetComponent<StoveManager>().cookedFood[stove.GetComponent<StoveManager>().food.IndexOf(stove.GetComponent<StoveManager>().contents)];
                GetComponent<InteractiveDetection>().isInteracting = false;
                stove.GetComponent<StoveManager>().contents = "";
                stove.GetComponent<StoveManager>().stove.GetComponent<InteractiveDetection>().isInteracting = false;
            }
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
