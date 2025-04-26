using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManagement : MonoBehaviour
{
    public List<GameObject> interactives = new List<GameObject>();
    public bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canInteract = true;
        for (int index = 0; index < interactives.Count; index++)
        {
            if (interactives[index].GetComponent<InteractiveDetection>().isInteracting)
            {
                canInteract = false;
            }
        }
    }
}
