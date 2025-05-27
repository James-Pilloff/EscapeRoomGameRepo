using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfManager : MonoBehaviour
{
    public GameObject bookshelf;
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bookshelf.GetComponent<InteractiveDetection>().isInteracting)
        {
            if (grabbed)
            {
                bookshelf.GetComponent<InteractiveDetection>().isInteracting = false;
            }
        }

        GetComponent<SpriteRenderer>().enabled = bookshelf.GetComponent<InteractiveDetection>().isInteracting;
    }
}
