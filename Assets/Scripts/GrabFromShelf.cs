using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFromShelf : MonoBehaviour
{
    public GameObject shelf;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shelf.GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            if (GetComponent<InteractiveDetection>().isInteracting)
            {
                item.GetComponent<GrabbableBehavior>().Hold();
                GetComponent<InteractiveDetection>().isInteracting = false;
                shelf.GetComponent<BookshelfManager>().grabbed = true;
            }
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
