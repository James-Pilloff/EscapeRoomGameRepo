using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveOnInteraction : MonoBehaviour
{
    public GameObject item;

    private bool hasGiven;

    // Start is called before the first frame update
    void Start()
    {
        hasGiven = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractiveDetection>().isInteracting)
        {
            if (!hasGiven)
            {
                item.GetComponent<GrabbableBehavior>().Hold();
                hasGiven = true;
            }
            GetComponent<InteractiveDetection>().isInteracting = false;
        }
    }
}
