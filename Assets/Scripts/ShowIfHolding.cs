using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIfHolding : MonoBehaviour
{
    public GameObject invent;
    public string item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = invent.GetComponent<InventoryManagement>().holding == item;
    }
}
