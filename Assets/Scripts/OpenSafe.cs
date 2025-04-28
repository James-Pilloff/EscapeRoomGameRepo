using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafe : MonoBehaviour
{
    public GameObject safe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractiveDetection>().isInteracting)
        {
            if (safe.GetComponent<SafeBehavior>().locked)
            {
                safe.GetComponent<SafeBehavior>().open = true;
            } else
            {
                GetComponent<InteractiveDetection>().isInteracting = false;
            }
        }
    }
}
