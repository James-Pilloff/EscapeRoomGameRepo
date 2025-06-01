using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableBehavior : MonoBehaviour
{
    public GameObject invent;
    public GameObject player;
    public string objectName;
    public GameObject stove;
    public Vector3 nullPos = new Vector3(-6.5f, 5.5f, 0.0f);

    private bool isHeld;

    public void Hold()
    {
        invent.GetComponent<InventoryManagement>().holding = objectName;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isHeld = invent.GetComponent<InventoryManagement>().holding == objectName;
        if (GetComponent<InteractiveDetection>().isInteracting)
        {
            invent.GetComponent<InventoryManagement>().holding = objectName;
            GetComponent<InteractiveDetection>().isInteracting = false;
        }

        if (isHeld)
        {
            transform.position = player.transform.position;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        } else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }

        if (stove.GetComponent<StoveManager>().contents == objectName)
        {
            transform.position = nullPos;
        }

        if (invent.GetComponent<InventoryManagement>().foods.Contains(objectName))
        {
            transform.position = invent.GetComponent<InventoryManagement>().positions[invent.GetComponent<InventoryManagement>().foods.IndexOf(objectName)];
        }
    }
}
