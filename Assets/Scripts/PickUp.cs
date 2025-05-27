using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractiveDetection>().isInteracting)
        {
            item.GetComponent<GrabbableBehavior>().Hold();
            GetComponent<InteractiveDetection>().isInteracting = false;
        }
    }
}
