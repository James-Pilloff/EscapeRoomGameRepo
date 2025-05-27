using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFromSafe : MonoBehaviour
{
    public GameObject safe;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (safe.GetComponent<SafePart2Behavior>().open)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            if (GetComponent<InteractiveDetection>().isInteracting)
            {
                item.GetComponent<GrabbableBehavior>().Hold();
                GetComponent<InteractiveDetection>().isInteracting = false;
                safe.GetComponent<SafePart2Behavior>().grabbed = true;
            }
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
