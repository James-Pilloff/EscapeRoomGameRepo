using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafe : MonoBehaviour
{
    public GameObject safe;
    public GameObject safe2;

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
                safe2.GetComponent<SafePart2Behavior>().open = false;
            } else
            {
                safe.GetComponent<SafeBehavior>().open = false;
                if (safe2.GetComponent<SafePart2Behavior>().grabbed)
                {
                    GetComponent<InteractiveDetection>().isInteracting = false;
                    safe.GetComponent<SafeBehavior>().open = false;
                    safe2.GetComponent<SafePart2Behavior>().open = false;
                } else
                {
                    safe.GetComponent<SafeBehavior>().open = false;
                    safe2.GetComponent<SafePart2Behavior>().open = true;
                }
                
            }
        } else
        {
            safe.GetComponent<SafeBehavior>().open = false;
            safe2.GetComponent<SafePart2Behavior>().open = false;
        }
    }
}
