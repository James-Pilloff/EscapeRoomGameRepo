using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIfHolding : MonoBehaviour
{
    public GameObject invent;
    public GameObject painting;
    public string item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = (painting.GetComponent<InteractiveDetection>().isInteracting);

        if (invent.GetComponent<InventoryManagement>().holding != item)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
